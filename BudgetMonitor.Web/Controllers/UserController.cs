using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BudgetMonitor.Web.Models;
using BudgetMonitor.Web.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMonitor.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository repository;
        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View(new User());
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            User user = new User();
            if (id == null)
                return View(user);
            user = await repository.GetAsync(StaticDetails.UserAPIPath, id.GetValueOrDefault());
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(User user)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] fileArray = null;
                    using (var fs = files[0].OpenReadStream())
                    {
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            fileArray = ms.ToArray();
                        }
                    }
                    user.Picture = fileArray;
                }
                else
                {
                    var objFromDb = await repository.GetAsync(StaticDetails.UserAPIPath, user.Id);
                    user.Picture = objFromDb.Picture;
                }
                if (user.Id == 0)
                    await repository.CreateAsync(StaticDetails.UserAPIPath, user);
                else
                    await repository.UpdateAsync(StaticDetails.UserAPIPath + user.Id, user);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(user);
        }

        public async Task<IActionResult> GetAllUsers()
        {
            return Json(new { data = await repository.GetAllAsync(StaticDetails.UserAPIPath) });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await repository.DeleteAsync(StaticDetails.UserAPIPath, id);
            if(status)
                return Json(new { success = true, message = "Delete Successful" });
            return Json(new { success = false, message = "Delete Not Successful" });
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}

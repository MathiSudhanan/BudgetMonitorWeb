using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetMonitor.Web.Models;
using BudgetMonitor.Web.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace BudgetMonitor.Web.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository repository;
        public TransactionController(ITransactionRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllTransactions()
        {
            var bearerToken = HttpContext.Session.GetString("JWToken");
            var result = await repository.GetAllAsync(StaticDetails.TransactionAPIPath, bearerToken);
            return Json(new { data = result });

        }

        public async Task<IActionResult> Upsert(int? id)
        {

            Transaction transaction = new Transaction();
            transaction.TransactionDate = DateTime.Now;
            if (id == null)
                return View(transaction);
            var bearerToken = HttpContext.Session.GetString("JWToken");

            transaction = await repository.GetAsync(StaticDetails.TransactionAPIPath, bearerToken, id.Value);
            if (transaction == null)
            {
                return NotFound();
            }
            return View(transaction);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
            var bearerToken = HttpContext.Session.GetString("JWToken");

                if (transaction.Id == 0)
                    await repository.CreateAsync(StaticDetails.TransactionAPIPath, bearerToken, transaction);
                else
                    await repository.UpdateAsync(StaticDetails.TransactionAPIPath + transaction.Id, bearerToken, transaction);
                return RedirectToAction(nameof(Index));
            }
            else
                return View(transaction);
        }

       


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bearerToken = HttpContext.Session.GetString("JWToken");

            var status = await repository.DeleteAsync(StaticDetails.TransactionAPIPath, bearerToken, id);
            if (status)
                return Json(new { success = true, message = "Delete Successful" });
            return Json(new { success = false, message = "Delete Not Successful" });
        }
    }
}

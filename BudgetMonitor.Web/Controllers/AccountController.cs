using BudgetMonitor.Web.Models;
using BudgetMonitor.Web.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BudgetMonitor.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            var authModel = new AuthenticationModel();
            return View(authModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthenticationModel authenticationModel)
        {
            var obj = await accountRepository.LoginAsync(StaticDetails.UserAPIPath + "AuthenticateUser/", authenticationModel);
            if (obj.Token == null)
                return View();
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, obj.UserName));
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            TempData["alert"] = "Welcome " + obj.UserName + "!";
            HttpContext.Session.SetString("JWToken", obj.Token);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            var userModel = new User();
            return View(userModel);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User userModel)
        {
            var bearerToken = HttpContext.Session.GetString("JWToken");

            var result = await accountRepository.RegisterAsync(StaticDetails.UserAPIPath + "RegisterUser/",  userModel);


            if (result)
            {
                TempData["alert"] = "Registration suceessful for  " + userModel.FirstName +" " + userModel.LastName+ "!";
                return RedirectToAction("Login");
            }

            return View(userModel);

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("JWToken", "");
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

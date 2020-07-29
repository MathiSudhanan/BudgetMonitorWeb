using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authentication;
using System.Linq;

namespace BudgetMonitor.Web.Filters
{
    public class SessionTimeoutFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RouteData.Values.Values.ToArray()[1].ToString() != "Login" && filterContext.RouteData.Values.Values.ToArray()[1].ToString() != "Register")
            {
                if (filterContext.HttpContext.Session.GetString("JWToken") == null)
                {
                    //filterContext.HttpContext.SignOutAsync();
                    filterContext.Result = new RedirectResult("~/Account/Login");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }    
    
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Extensions;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Filters
{
    public class CheckSession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Employee loggedInEmployee = context.HttpContext.Session.GetObject<Employee>("LoggedInUser");

            if (loggedInEmployee == null)
                context.Result = new RedirectToActionResult("LogIn", "Authentication", new { area = "Admin" });
                   
        }
    }
}

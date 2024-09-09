using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Extensions;

namespace NorthwndApp.MvcWebUI.Areas.Satici.Filters
{
    public class SaticiCheckSession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Supplier loggedInEmployee = context.HttpContext.Session.GetObject<Supplier>("LoggedInUser");

            if (loggedInEmployee == null)
                context.Result = new RedirectToActionResult("Login", "Login", new { area = "Satici" });
                   
        }
    }
}

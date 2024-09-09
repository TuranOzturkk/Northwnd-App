using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Extensions;

namespace NorthwndApp.MvcWebUI.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            Employee loggedInEmployee = HttpContext.Session.GetObject<Employee>("LoggedInUser");

            return View(loggedInEmployee);
        }
    }
}

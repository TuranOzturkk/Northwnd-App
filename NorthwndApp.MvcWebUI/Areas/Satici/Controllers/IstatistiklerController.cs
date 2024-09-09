using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Satici.Filters;
using NorthwndApp.MvcWebUI.Extensions;

namespace NorthwndApp.MvcWebUI.Areas.Satici.Controllers
{
    [Area("Satici")]
    [SaticiCheckSession]
    public class IstatistiklerController : Controller
    {
        public IActionResult Index()
        {
            Supplier sup = HttpContext.Session.GetObject<Supplier>("LoggedInUser");
            ViewBag.saticiadi = sup.ContactName;
            ViewBag.sirketadi = sup.CompanyName;
            if (sup != null)
            {
                return View(sup);
            }
            return RedirectToAction("Login", "Giris");
           
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;
using NorthwndApp.MvcWebUI.Areas.Satici.Filters;
using NorthwndApp.MvcWebUI.Areas.Satici.Models;
using NorthwndApp.MvcWebUI.Extensions;
using System;

namespace NorthwndApp.MvcWebUI.Areas.Satici.Controllers
{
    [Area("Satici")]
    [SaticiCheckSession]
    public class HomeController : Controller
    {
        private readonly ISupplierBs _supplierBs;
        public HomeController(ISupplierBs supplierBs)
        {
            _supplierBs = supplierBs;
        }
        public IActionResult Hesap(Supplier supplier)
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
        [HttpPost]
        public IActionResult Update(Supplier supplier)
        {
            Supplier ToUpdate = _supplierBs.GetById(supplier.SupplierId);

            ToUpdate.City = supplier.City;
            ToUpdate.Phone = supplier.Phone;
            ToUpdate.Address = supplier.Address;
            ToUpdate.Mail = supplier.Mail;

            _supplierBs.Update(ToUpdate);

            return Json(new { IsSuccess = true, Message = "Bilgiler Güncellendi." });
            
        }
    }
}

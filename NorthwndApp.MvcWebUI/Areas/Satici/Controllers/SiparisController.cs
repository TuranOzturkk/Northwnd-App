using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using NorthwndApp.MvcWebUI.Areas.Satici.Filters;
using NorthwndApp.MvcWebUI.Areas.Satici.Models;
using NorthwndApp.MvcWebUI.Extensions;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Satici.Controllers
{
    [Area("Satici")]
    [SaticiCheckSession]
    public class SiparisController : Controller
    {

        private readonly ISupplierBs _supplierBs;
        private readonly IOrderBs _orderBs;
        private readonly IMapper _mapper;
        public SiparisController(ISupplierBs supplierBs,IOrderBs orderBs,IMapper mapper)
        {
            _supplierBs = supplierBs;
            _orderBs = orderBs;
            _mapper = mapper;
        }
        public IActionResult Index()
        {

            Supplier sup = HttpContext.Session.GetObject<Supplier>("LoggedInUser");
            ViewBag.saticiadi = sup.ContactName;
            ViewBag.sirketadi = sup.CompanyName;

            List<Order> order = _orderBs.GetList();
            
            
                foreach (Order orderItem in order)
                {
                    if (orderItem.SuppliersID == sup.SupplierId)
                    {
                        ViewBag.supid = sup.SupplierId;
                        return View(order);
                    }
                }
           
           
            ViewBag.Result = "<div class='alert alert-danger'>Siparişiniz Bulunmamakta...</div>";
            return View();

        }
        [HttpGet]
        public  IActionResult Kverildi(int id)
        {
            Order Order = _orderBs.GetById(id);

            Order.SipKargoverildi = true;

            _orderBs.Update(Order);


            return Json(new { IsSuccess = true, Message = "Kargoya Verildi" });
        }
        [HttpGet]
        public  IActionResult Onay(int id)
        {
            Order Order = _orderBs.GetById(id);

            Order.SipOnay = true;

            _orderBs.Update(Order);


            return Json(new { IsSuccess = true, Message = "Onaylandı" });
        }

    }
}

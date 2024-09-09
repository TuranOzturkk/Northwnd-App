using AutoMapper;

using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using NorthwndApp.MvcWebUI.Extensions;
using NorthwndApp.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckSession]
    public class HomeController : Controller
    {
        private readonly IIletisimBs _iletisimBs;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public HomeController(IIletisimBs iletisimBs, IMapper mapper, IConfiguration configuration)
        {
            _iletisimBs = iletisimBs;
            _mapper = mapper;
            _configuration = configuration;
        }
            public IActionResult Index(Iletisim iletisim)
            {

            
            
            Employee loggedInEmployee = HttpContext.Session.GetObject<Employee>("LoggedInUser");
            return View(loggedInEmployee);
            }

        public IActionResult Mesaj()
        {
            //MesajViewModel.iletisimlist = _iletisimBs.GetList();
            List<Iletisim> iletisim = _iletisimBs.GetList();

            return View(iletisim);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {


            var iletisim = JsonConvert.SerializeObject(_iletisimBs.GetById(id));
            ViewBag.id = id;
           

            
            return Json(iletisim);

        }


        [HttpPost]
        public IActionResult Update(Iletisim iletisim)
        {
            Iletisim ToUpdate = _iletisimBs.GetById(iletisim.IletisimID);

            ToUpdate.Adi = iletisim.Adi;
            ToUpdate.Mail = iletisim.Mail;
            ToUpdate.Active = false;
            ToUpdate.Cevap = iletisim.Cevap;
            
            _iletisimBs.Update(ToUpdate);


            // MAIL GÖNDER
            //string Cevap = iletisim.Cevap;

            //string Mail = iletisim.Mail;

            //string message = $"{iletisim.Adi} bey <br /> Kaydınızın onaylanması için lütfen tıklayın : <br />";

            //MailHelper.iletisimmail(Mail, iletisim.Mail, "Müşteri Temsilcisinin Cevabı", message);

            //----------------------------

            return Json(new { IsSuccess = true, Message = "Mail Gönderildi" });

        }
    }
}

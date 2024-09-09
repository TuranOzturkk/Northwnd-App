using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Models;

namespace NorthwndApp.MvcWebUI.Controllers
{
    public class IletisimController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IIletisimBs _iletisimBs;
        public IletisimController(IMapper mapper, IIletisimBs iletisimBs)
        {
            _iletisimBs = iletisimBs;
             _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Mesaj(Iletisim model)
        {
            Iletisim iletisim = _mapper.Map<Iletisim>(model);
            iletisim.Active = true;

            if (model.Adi != null && model.Mail != null && model.Konu != null && model.Mesa != null)
            {
               
                _iletisimBs.Insert(iletisim);
                return Json(new { IsSuccess = true, Message = "Mesajınız başarılı bir şekilde gönderildi..." });
            }
            return Json(new { IsSuccess = false, Message = "Lütfen Boş Alanları Doldurunuz !" });

        }
    }
}

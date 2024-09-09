using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;

using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckSession]
    public class MusterilerController : Controller
    {
        private readonly IMusterilerBs _MusterilerBs;
        private readonly IMapper _Mapper;
        public MusterilerController(IMusterilerBs musterilerBs, IMapper mapper)
        {
            
            _MusterilerBs = musterilerBs;
            _Mapper = mapper;
        }
        
        public IActionResult Index()
        {
            List<Musteriler> musteriler = _MusterilerBs.GetList();
            return View(musteriler);

        }
        [HttpPost]

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _MusterilerBs.Delete(_MusterilerBs.GetById(id));
            
            return Json(new { IsSuccess = true });
        }
        [HttpPost]
        public IActionResult GetMusteriler(int id)
        {
            Musteriler musteriler = _MusterilerBs.GetById(id);

            return Json(new { IsSuccess = true, Musteriler = musteriler });
        }

    }

    
}

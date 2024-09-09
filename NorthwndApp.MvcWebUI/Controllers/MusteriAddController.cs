using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Models;

namespace NorthwndApp.MvcWebUI.Controllers
{
    public class MusteriAddController : Controller
    {
        private readonly IMusterilerBs _musterilerBs;
        private readonly IMapper _mapper;

        public MusteriAddController(IMusterilerBs musterilerBs, IMapper mapper)
        {
            _musterilerBs = musterilerBs;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Add(MusterilerAddDto model)
        {

            Musteriler musteriler = _mapper.Map<Musteriler>(model);
            musteriler.Parola = CryptoHelper.AESEncrypt(musteriler.Parola, "LoggedInUser");

            _musterilerBs.Insert(musteriler);
            return Json(new { IsSuccess = true, Message = "Kaydınız başarılı bir şekilde gerçekleşti..." });
        }
    }
}

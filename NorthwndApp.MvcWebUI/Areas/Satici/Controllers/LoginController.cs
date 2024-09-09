using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Satici.Models;
using NorthwndApp.MvcWebUI.Extensions;
using NorthwndApp.MvcWebUI.Statics;


namespace NorthwndApp.MvcWebUI.Areas.Satici.Controllers
{
    [Area("Satici")]
    
    public class LoginController : Controller
    {
        private readonly ISupplierBs _supplierBs;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public LoginController(ISupplierBs supplierBs, IConfiguration configuration,IMapper mapper)
        {
            _supplierBs = supplierBs;
            _configuration = configuration;
            _mapper = mapper;
        }
        
        
        public IActionResult Login()
        {
           
            
            
            return View();
        }
        [HttpPost]
        public IActionResult Giris(LoginViewModel model)
        {
            model.KullaniciParola = CryptoHelper.AESEncrypt(model.KullaniciParola, _configuration.GetSection("EncryptionKey").Value);

            Supplier supplier = _supplierBs.LogIn(model.KullaniciAdi, model.KullaniciParola);




            if (supplier != null)
            {
                if (model.KullaniciAdi == supplier.KullaniciAdi)
                {
                    if (model.KullaniciParola == model.KullaniciParola)
                    {
                        HttpContext.Session.SetObject("LoggedInUser", supplier);
                        return Json(new { IsSuccess = true });
                    }
                    return Json(new { IsSuccess = false, Message = "Kullanıcı Adınız veya Parolanız Hatalı." });
                }
                return Json(new { IsSuccess = false, Message = "Kullanıcı Adınız veya Parolanız Hatalı." });

            }

            return Json(new { IsSuccess = false, Message = Messages.USER_NOT_FOUND });

        }
        [HttpPost]
        public IActionResult Kayitol(Supplier model)
        {
            if (model.KullaniciParola.Length >= 8)
            {
                Supplier supplier = _mapper.Map<Supplier>(model);
                supplier.KullaniciParola = CryptoHelper.AESEncrypt(supplier.KullaniciParola, _configuration.GetSection("EncryptionKey").Value);
                supplier.IsActive = true;
                supplier.ApprovingCode = RandomValueGenerator.GenerateApprovingCode();
                _supplierBs.Insert(supplier);

                // MAIL GÖNDER
                //string email = _configuration.GetSection("EmailAddress").Value;
                //string pass = _configuration.GetSection("EmailPassword").Value;

                //string message = $"Sayın {musteriler.Adi} {musteriler.Soyadi} <br /> Kaydınızın onaylanması için lütfen tıklayın : <br /><a href='http://localhost:57985/Approving/MusterilerApprove/{musteriler.ApprovingCode}'>ONAYLA</a>";

                //MailHelper.SendMail(email, musteriler.Mail, "Deneme Atışı", message, pass);

                //----------------------------


                return Json(new { IsSuccess = true, Message = Messages.SAVE_MUSTERILER_SUCCEEDED });

            }
            return Json(new { IsSuccess = false, Message = "Parolanız 8 karakterden az olamaz!" });

        }




    }
}

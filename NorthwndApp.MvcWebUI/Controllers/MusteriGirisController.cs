using Abp.Json;
using AutoMapper;
using Castle.DynamicProxy;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Extensions;
using NorthwndApp.MvcWebUI.Models;
using NorthwndApp.MvcWebUI.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwndApp.MvcWebUI.Controllers
{
    public class MusteriGirisController : Controller
    {
        private readonly IMusterilerBs _musterilerBs;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IOrderBs _orderBs;
        private readonly ISepetBs _sepetBs;
        private readonly IProductBs _productBs;
        public MusteriGirisController(IMusterilerBs musterilerBs, IMapper mapper, IConfiguration configuration, IOrderBs orderBs,ISepetBs sepetBs,IProductBs productBs)
        {
            _musterilerBs = musterilerBs;
            _mapper = mapper;
            _configuration = configuration;
            _orderBs = orderBs;
            _sepetBs = sepetBs;
            _productBs = productBs;
        }
        public IActionResult Hesabim(SepetDto model,Product product)
        {
            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");

            if (loggedInMusteriler != null)
            {
                ViewBag.mustreri = loggedInMusteriler.Adi + " " + loggedInMusteriler.Soyadi;
                var sep = _sepetBs.GetList(x => x.MusteriID == loggedInMusteriler.MusteriID);
                ViewBag.toplam = (sep.Sum(x => x.Fiyat) * (sep.Sum(y => y.SepAdet)));

                decimal toplam = 0;

                    for (int i = 0; i < sep.Count; i++)
                    {
                        decimal Sepet = Convert.ToDecimal(sep[i].Fiyat);

                         int adet =Convert.ToInt32(sep[i].SepAdet);

                         toplam += Sepet * adet;
                    }

                ViewBag.deneme = toplam;

                return View(sep);
            }
            return RedirectToAction("LogIn", "MusteriGiris");
 
        }


        public IActionResult Sipver(Order model)
        {
            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");
            var sep = _sepetBs.GetList(x => x.MusteriID == loggedInMusteriler.MusteriID);




            for (int i = 0; i < sep.Count; i++)
            {
               

                var Product = _productBs.GetById(Convert.ToInt32(sep[i].UrunID));
                Order order = new Order();
                


                //var order = _mapper.Map<Order>(model);
                order.ProductsID = (sep[i].UrunID);
                order.SuppliersID = Product.SupplierID;
                order.UrunAdi = Product.ProductName;
                order.Adet = (sep[i].SepAdet);
                order.Freight = Convert.ToDecimal((sep[i].Fiyat) * (sep[i].SepAdet));

                order.MusterilerID = loggedInMusteriler.MusteriID;
                order.MusAdi = loggedInMusteriler.Adi;
                order.MusSoyadi = loggedInMusteriler.Soyadi;
                order.MusTelefon = loggedInMusteriler.Telefon;
                order.MusterilerID = loggedInMusteriler.MusteriID;

                order.ShipAddress = loggedInMusteriler.Adres;
                order.ShipCity = loggedInMusteriler.Sehir;
                order.ShipCountry = loggedInMusteriler.Ulke;



                _orderBs.Insert(order);


                Sepet sepetDelete = _sepetBs.GetById(sep[i].SepetID);
                _sepetBs.Delete(sepetDelete);


            }


           
            return RedirectToAction("Siparis", "MusteriGiris");
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            _sepetBs.Delete(_sepetBs.GetById(id));

            return Json(new { IsSuccess = true });



        }



        public IActionResult Hesapbilgi()
        {
            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");
            
            if (loggedInMusteriler != null)
            {
                return View(loggedInMusteriler);
            }
            return RedirectToAction("LogIn", "MusteriGiris");
        }

        public IActionResult Siparis(Order ord)
        {
            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");
            if (loggedInMusteriler != null)
            {

                List<Order> order = _orderBs.GetList(x => x.MusterilerID == loggedInMusteriler.MusteriID);

                return View(order);
            }
            return RedirectToAction("LogIn", "MusteriGiris");
        }
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            
            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");
            //public static System.Threading.Tasks.Task SignOutAsync(this Microsoft.AspNetCore.Http.HttpContext loggedInMusteriler);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogIn", "MusteriGiris");
        }


        public IActionResult MusteriKayit(MusterilerGet MusterilerGet)
        {
            List<Musteriler> musteriler = _musterilerBs.GetList();
            return View(musteriler);
        }   

        [HttpPost]
        
        public IActionResult Add(Musteriler model)
        {
            //Musteriler musterilermail = _musterilerBs.MailControl(model.Mail);

            //int sifir = Convert.ToInt32(musterilermail);


            //if (sifir == 1)
            //{
            //    return Json(new { IsSuccess = false, musterilermail = musterilermail, Message = "Mail Kayıtlı" });
            //}


            if (model.Mail == null)
            {
                return Json(new { IsSuccess = false, Message = "Lütfen Mail Hesabınızı Giriniz" });
            }
            if (model.Adi == null)
            {
                return Json(new { IsSuccess = false, Message = "Adınızı Giriniz" });
            }
            if (model.Soyadi == null)
            {
                return Json(new { IsSuccess = false, Message = "Soyadınızı Giriniz" });
            }
            if (model.KullaniciAdi == null)
            {
                return Json(new { IsSuccess = false, Message = "Kullanıcı Adı belirleyiniz!" });
            }
            if (model.Parola != model.ParolaSorgu)
            {
                return Json(new { IsSuccess = false, Message = "Parolanız Aynı Değil" });
            }
 
            if (model.Parola.Length >= 8)
                {
                    Musteriler musteriler = _mapper.Map<Musteriler>(model);
                    musteriler.Parola = CryptoHelper.AESEncrypt(musteriler.Parola, _configuration.GetSection("EncryptionKey").Value);
                musteriler.IsActive = true;
                musteriler.ApprovingCode = RandomValueGenerator.GenerateApprovingCode();
                _musterilerBs.Insert(musteriler);

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
          

            [HttpPost]
        public IActionResult LogIn(MusteriGirisLogInVm model)
        {
           
                model.Parola = CryptoHelper.AESEncrypt(model.Parola, _configuration.GetSection("EncryptionKey").Value);
            

            Musteriler musteriler = _musterilerBs.LogIn(model.KullaniciAdi, model.Parola);



            if (musteriler == null)
                return Json(new { IsSuccess = false, Message = Messages.USER_NOT_FOUND });
            //return Json(new { IsSuccess = false, Message = "Böyle Bir Kullanıcı Bulunamadı" });

            HttpContext.Session.SetObject(Messages.KULLANICI_KEY_DEGERI, musteriler);

            return Json(new{ IsSuccess = true});
        }
    }
}

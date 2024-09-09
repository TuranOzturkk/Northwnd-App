using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Extensions;
using NorthwndApp.MvcWebUI.Models;
using System.Linq;
using System;
using X.PagedList;
using NorthwndApp.Business.Concrete;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Controllers
{
    public class UrunController : Controller
    {
        private readonly IProductYorumBs _productYorumBs;
        private readonly IProductBs _productBs;
        private readonly IMusterilerBs _musterilerBs;
        private readonly IOrderDetailBs _odBs;
        private readonly ICategoryBs _categoryBs;
        private readonly ISepetBs _sepetBs;
       
        private readonly IMapper _mapper;
        public UrunController(IProductBs productBs, IOrderDetailBs odBs, IMapper mapper, IProductYorumBs productYorumBs, IMusterilerBs musterilerBs,ICategoryBs categoryBs,ISepetBs sepetBs)
        {
            _productBs = productBs;
            _odBs = odBs;
            _mapper = mapper;
            _productYorumBs = productYorumBs;
            _musterilerBs = musterilerBs;
            _categoryBs = categoryBs;
            _sepetBs = sepetBs;
        }
         
        public IActionResult Default(int page = 1)
        {
            //var featuredProducts = _odBs.GetUrun("Product", "Product.ProductPhotos");
            //return View((featuredProducts).ToPagedList(page,20));


            List<Product> product = _productBs.GetList();
            return View((product).ToPagedList(page,20));
        }

        [HttpGet]
        public IActionResult UrunDetail(UrunProductYorumViewModel UrunProductYorumViewModel, int id)
        {

            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");

            UrunProductYorumViewModel.Category = _categoryBs.GetById(id);
            UrunProductYorumViewModel.Musteriler = _musterilerBs.GetById(id);
            UrunProductYorumViewModel.ProductYorum = _productYorumBs.GetById(id);
            UrunProductYorumViewModel.Product = _productBs.GetById(id);
            UrunProductYorumViewModel.ProductYorumlistesi = _productYorumBs.GetList();
            UrunProductYorumViewModel.Productlistesi = _productBs.GetList();
            UrunProductYorumViewModel.Musterilerlistesi = _musterilerBs.GetList();

            //product'a gore toplam yorum sayisi baslangic//
            foreach (var yorumlist in UrunProductYorumViewModel.ProductYorumlistesi)
            {
                ViewBag.yrm = Convert.ToInt32(UrunProductYorumViewModel.ProductYorumlistesi.Count(x => x.ProductyorumID == id));
            }
            //product'a gore toplam yorum sayisi bitis//

            ViewBag.deger = id;
            if (loggedInMusteriler == null)
            {
               ViewBag.kullanici = null;
                return View(UrunProductYorumViewModel);
            }
            else
               ViewBag.kullanici = loggedInMusteriler.MusteriID;
               return View(UrunProductYorumViewModel);

        }
        [HttpPost]
       public IActionResult Sepetekle(int id, Sepet model,Product product)
        {
            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");
            if (loggedInMusteriler != null)
            {
                Sepet sepet = _mapper.Map<Sepet>(model);

                var pro = _productBs.GetById(id);



                sepet.UrunID = pro.ProductId;
                sepet.MusteriID = loggedInMusteriler.MusteriID;
                sepet.Fiyat = pro.UnitPrice;
                sepet.Adi = pro.ProductName;
                sepet.Fotograf = pro.Fotografbir;
                sepet.SepAdet = model.SepAdet;



                _sepetBs.Insert(sepet);

                return Json(new { IsSuccess = true });
            }


            return Json(new { IsSuccess = false, Message = "Sepetinize Ürün Eklemek İçin Giriş Yapınız !" });

        }

        [HttpPost]
        public IActionResult YorumOnay(ProductYorum model, int id, UrunProductYorumViewModel UrunProductYorumViewModel)
        {
            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");
            if (loggedInMusteriler != null)
            {
                UrunProductYorumViewModel.Musterilerlistesi = _musterilerBs.GetList();
             

                        ProductYorum ProductYorum = _mapper.Map<ProductYorum>(model);
                        
                        _productYorumBs.Insert(ProductYorum);
                       
                        return Json(new { IsSuccess = true, Message = "Yorum Yapıldı" });

                
            }
            return Json(new { IsSuccess = false, Message = "Oturum Açmadan Yorum Yapamazsınız." });


        }


        public IActionResult CategoryUrun(HomeIndexViewModel HomeIndexViewModel, int id)
        {

           


            HomeIndexViewModel.Categories = _categoryBs.GetList();
            HomeIndexViewModel.Products = _productBs.GetList();
            
            foreach (var products in HomeIndexViewModel.Products)
            {
                if (products.CategoryID == id)
                {
                  
                    ViewBag.catid = id;
                    //var featuredProducts = _odBs.GetUrun("Product", "Product.ProductPhotos");
                    //return View(featuredProducts);

                    List<Product> product = _productBs.GetList();
                    return View(product);
                }
                
                
            }
            List<Product> productbos = _productBs.GetList();
            return View(productbos);
        }
    }
}

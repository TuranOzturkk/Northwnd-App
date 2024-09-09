using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using NorthwndApp.MvcWebUI.Areas.Satici.Filters;
using NorthwndApp.MvcWebUI.Areas.Satici.Models;
using NorthwndApp.MvcWebUI.Extensions;
using NorthwndApp.MvcWebUI.Models;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using X.PagedList;

namespace NorthwndApp.MvcWebUI.Areas.Satici.Controllers
{
    [Area("Satici")]
    [SaticiCheckSession]
    public class UrunController : Controller
    {
        private readonly IProductBs _productBs;
        private readonly IOrderDetailBs _odBs;
        private readonly IMapper _mapper;
        private readonly ICategoryBs _categoryBs;
        private readonly ISupplierBs _supplierBs;
        
        public UrunController(IProductBs productBs, IOrderDetailBs odBs, IMapper mapper, ICategoryBs categoryBs, ISupplierBs supplierBs)
        {
            _productBs = productBs;
            _odBs = odBs;
            _mapper = mapper;
            _categoryBs = categoryBs;
            _supplierBs = supplierBs;
           
        }
        public IActionResult Index()
        {
            Supplier sup = HttpContext.Session.GetObject<Supplier>("LoggedInUser");
            List<Product> prolist = _productBs.GetList();
            ViewBag.saticiadi = sup.ContactName;
            ViewBag.sirketadi = sup.CompanyName;
            //var featuredProducts = _odBs.GetUrun("Product", "Product.ProductPhotos");
            ViewBag.supid = sup.SupplierId;

            //return View(prolist);
            return View(SetModelForPage());
        }
        [HttpPost]
        public  IActionResult Delete(int id)
        {
            _productBs.Delete(_productBs.GetById(id));

            return Json(new { IsSuccess = true });


           
        }


        private ProductAddViewModelSatici SetModelForPage()
        {

            ProductAddViewModelSatici viewModel = new ProductAddViewModelSatici();

            viewModel.Categories = _categoryBs.GetList().Select(cat =>
            new SelectListItem()
            {
                Text = cat.CategoryName,
                Value = cat.CategoryId.ToString()
            }).ToList();

            List<Product> prolist = _productBs.GetList();

            ViewBag.prolist = prolist;

            return viewModel;
        }
        [HttpPost]
        public IActionResult Add(Product model, IFormFile Fotografbir,OrderDetail orderdetail)
        {
            Supplier sup = HttpContext.Session.GetObject<Supplier>("LoggedInUser");

            if (Fotografbir != null)
            {
                

                if (Fotografbir.Length > 1000 * 1024)
                    return Json(new { IsSuccess = false, Message = "Dosya 1000 KB dan büyük olamaz" });

                if (!Fotografbir.ContentType.StartsWith("image/"))
                    return Json(new { IsSuccess = false, Message = "Lütfen sadece resim dosyası seçiniz" });

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AdminArea/CustomImages/ProductImages");
                string fileName = RandomValueGenerator.GenerateFileName(Path.GetExtension(Fotografbir.FileName));
                string fileNameWithPath = Path.Combine(path, fileName);

                using (FileStream stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    Fotografbir.CopyTo(stream);
                }

               


                Product product = _mapper.Map<Product>(model);
                product.Fotografbir = "/ProductImages/" + fileName;
                product.SupplierID = sup.SupplierId;

                

                _productBs.Insert(product);



                return Json(new { IsSuccess = true, Message = "Ürün Başarıyla Kaydedildi" });

            }
            else
                return Json(new { IsSuccess = false, Message = "Lütfen Ürün için resim ekleyiniz" });


        }


        [HttpGet]
        public IActionResult Get(int id)
        {


            var products = JsonConvert.SerializeObject(_productBs.GetById(id));


            return Json(products);

        }


        [HttpPost]
        public IActionResult Update(Product product)
        {

            //Product pro = _mapper.Map<Product>(product);

            //_productBs.Update(pro);


            Product ToUpdate = _productBs.GetById(product.ProductId);

            ToUpdate.ProductName = product.ProductName;
            ToUpdate.UnitPrice = product.UnitPrice;
            ToUpdate.UnitsInStock = product.UnitsInStock;
            ToUpdate.Description = product.Description;         
            ToUpdate.QuantityPerUnit = product.QuantityPerUnit;

            _productBs.Update(ToUpdate);

            

            return Json(new { IsSuccess = true, Message = "Ürün Güncellendi" });

        }



    }



}

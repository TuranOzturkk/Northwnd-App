using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using System.Collections.Generic;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckSession]
    public class OrderController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrderBs _orderBs;
        private readonly IProductBs _productBs;
        private readonly IMusterilerBs _musterilerBs;



        public OrderController(IOrderBs orderBs, IMapper mapper, IProductBs productBs, IMusterilerBs musterilerBs)
        {
            _mapper = mapper;
            _orderBs = orderBs;
            _productBs = productBs;
            _musterilerBs = musterilerBs;

        }
        public IActionResult Index()
        {
            OrPrMuViewModel OrPrMuViewModel = new OrPrMuViewModel();

            OrPrMuViewModel.Products = _productBs.GetList();
            OrPrMuViewModel.Orders = _orderBs.GetList();
           
            OrPrMuViewModel.Musteriler = _musterilerBs.GetList();

            return View(OrPrMuViewModel);




        }
        //public IActionResult Add(CategoryAddDto model, IFormFile categoryImage)
        //{
        //    if (categoryImage != null)
        //    {
        //        #region FILE UPLOAD TO PATH

        //        if (categoryImage.Length > 100 * 1024)
        //            return Json(new { IsSuccess = false, Message = "Dosya 100 KB dan büyük olamaz" });

        //        if (!categoryImage.ContentType.StartsWith("image/"))
        //            return Json(new { IsSuccess = false, Message = "Lütfen sadece resim dosyası seçiniz" });

        //        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AdminArea/CustomImages/CategoryImages");
        //        string fileName = RandomValueGenerator.GenerateFileName(Path.GetExtension(categoryImage.FileName));
        //        string fileNameWithPath = Path.Combine(path, fileName);

        //        using (FileStream stream = new FileStream(fileNameWithPath, FileMode.Create))
        //        {
        //            categoryImage.CopyTo(stream);
        //        }

        //        #endregion


        //        #region FILE INSERT AS BINARY

        //        byte[] bytes;
        //        using (BinaryReader br = new BinaryReader(categoryImage.OpenReadStream()))
        //        {
        //            bytes = br.ReadBytes((int)categoryImage.Length);
        //        }

        //        #endregion

        //        Category category = _mapper.Map<Category>(model);
        //        category.PicturePath = "/CategoryImages/" + fileName;
        //        category.Picture = bytes;

        //        _categoryBs.Insert(category);

        //        return Json(new { IsSuccess = true, Message = "Kategori Başarıyla Kaydedildi" });

        //    }
        //    else
        //        return Json(new { IsSuccess = false, Message = "Lütfen kategori için resim ekleyiniz" });


        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _orderBs.Delete(_orderBs.GetById(id));
            return Json(new { IsSuccess = true });
        }

        public IActionResult GetOrder(int id)
        {
            Order order = _orderBs.GetById(id);

            return Json(new { IsSuccess = true, Order = order });
        }
        public IActionResult Update(int id)
        {
            
            _orderBs.Update(_orderBs.GetById(id));
            return Json(new { IsSuccess = true });
        }
    }
}

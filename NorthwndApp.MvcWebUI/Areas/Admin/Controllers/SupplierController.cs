using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using System.Collections.Generic;
using System.IO;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckSession]
    public class SupplierController : Controller
    {
        private readonly ISupplierBs _supplierBs;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierBs supplierBs, IMapper mapper)
        {
            _supplierBs = supplierBs;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            List<Supplier> suppliers = _supplierBs.GetList();
            return View(suppliers);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _supplierBs.Delete(_supplierBs.GetById(id));

            return Json(new { IsSuccess = true });
        }
        [HttpPost]
        public IActionResult GetSuppliers(int id)
        {
            Supplier supplier = _supplierBs.GetById(id);

            return Json(new { IsSuccess = true, supplier = supplier });
        }



        //[HttpPost]
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




    }
}

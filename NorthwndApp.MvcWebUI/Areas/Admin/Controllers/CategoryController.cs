using AutoMapper;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using NorthwndApp.MvcWebUI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckSession]
    public class CategoryController : Controller
    {
        private readonly ICategoryBs _categoryBs;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryBs categoryBs, IMapper mapper)
        {
            _categoryBs = categoryBs;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            List<Category> categories = _categoryBs.GetList();
            return View(categories);
        }

        //[HttpPost]
        //public IActionResult Add(CategoryAddDto model)
        //{
        //    Category category = _mapper.Map<Category>(model);

        //    _categoryBs.Insert(category);

        //    return Json(new { IsSuccess=true,Message="Kategori Başarıyla Kaydedildi"});
        //}

        //[HttpPost]
        //public IActionResult Add()
        //{
        //    IFormCollection fc = Request.Form;

        //    string catName = fc["CategoryName"].ToString();
        //    string desc = fc["Description"].ToString();

        //    for (int i = 0; i < fc.Files.Count; i++)
        //    {
        //        string fileName = fc.Files[i].FileName;
        //    }

        //    return Json(new { });
        //}

        [HttpPost]
        public IActionResult Add(CategoryAddDto model, IFormFile categoryImage)
        {
            if (categoryImage != null)
            {
                #region FILE UPLOAD TO PATH

                if (categoryImage.Length > 1000 * 1024)
                    return Json(new { IsSuccess = false, Message = "Dosya 1000 KB dan büyük olamaz" });

                if (!categoryImage.ContentType.StartsWith("image/"))
                    return Json(new { IsSuccess = false, Message = "Lütfen sadece resim dosyası seçiniz" });

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/AdminArea/CustomImages/CategoryImages");
                string fileName = RandomValueGenerator.GenerateFileName(Path.GetExtension(categoryImage.FileName));
                string fileNameWithPath = Path.Combine(path, fileName);

                using (FileStream stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    categoryImage.CopyTo(stream);
                }

                #endregion


                #region FILE INSERT AS BINARY

                byte[] bytes;
                using (BinaryReader br = new BinaryReader(categoryImage.OpenReadStream()))
                {
                    bytes = br.ReadBytes((int)categoryImage.Length);
                }

                #endregion

                Category category = _mapper.Map<Category>(model);
                category.PicturePath = "/CategoryImages/" + fileName;
                category.Picture = bytes;

                _categoryBs.Insert(category);

                return Json(new { IsSuccess = true, Message = "Kategori Başarıyla Kaydedildi" });

            }
            else
                return Json(new { IsSuccess = false, Message = "Lütfen kategori için resim ekleyiniz" });


        }

      
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _categoryBs.Delete(_categoryBs.GetById(id));

            return Json(new { IsSuccess = true });
        }
        
        public IActionResult GetCategory(int id)
        {

           
            Category category = _categoryBs.GetById(id);

            return Json(new { IsSuccess = true, Category = category });
        }


        [HttpPost]
        public IActionResult Update(int id, Category category)
        {
            if (category.CategoryId == id)
            {

                Category ToUpdate = _categoryBs.GetById(category.CategoryId);

                ToUpdate.CategoryName = category.CategoryName;
                ToUpdate.Description = category.Description;

                _categoryBs.Update(ToUpdate);

            //CategoryAddDto vm = new CategoryAddDto();

            //vm.CategoryToUpdate = ToUpdate;

            return Json(new { IsSuccess = true, Message = "Kategori Başarıyla Kaydedildi" });

            }
            else
            {
                return Json(new { IsSuccess = true, Message = "Kayit Basarisiz" });
            }








        }

    }
}

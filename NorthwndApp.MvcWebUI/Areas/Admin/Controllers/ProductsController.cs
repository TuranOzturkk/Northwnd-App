using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient.Server;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Filters;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;
using NorthwndApp.MvcWebUI.Models;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace NorthwndApp.MvcWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [CheckSession]
    public class ProductsController : Controller
    {
        private readonly IProductBs _productBs;
        private readonly IMapper _mapper;
        private readonly ICategoryBs _categoryBs;
        private readonly ISupplierBs _supplierBs;
        public ProductsController(IProductBs productBs, IMapper mapper, ICategoryBs categoryBs, ISupplierBs supplierBs)
        {
            _productBs = productBs;
            _mapper = mapper;
            _categoryBs = categoryBs;
            _supplierBs = supplierBs;   
        }
        public IActionResult Index()
        {
            ProductsSupCatViewModel pscViewModel = new ProductsSupCatViewModel();
            pscViewModel.Products = _productBs.GetList();
            pscViewModel.Categories = _categoryBs.GetList();
            pscViewModel.Suppliers = _supplierBs.GetList();          
            return View(pscViewModel);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _productBs.Delete(_productBs.GetById(id));
            return Json(new {IsSuccess = true});
        }
        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            
            Product product = _productBs.GetById(id);
            return Json(new { IsSuccess = true, Product = product });

        }

        [HttpPost]
        public IActionResult Update(int id)
        {

            _productBs.Update(_productBs.GetById(id));
            return Json(new { IsSuccess = true });
        }

        //[HttpGet]
        //public IActionResult Updategel(int id)
        //{
        //    ProductsSupCatViewModel viewModel = new ProductsSupCatViewModel();
        //    viewModel.ProductUpdate = _productBs.GetById(id);
        //    return View(viewModel);
        //}

        //[HttpPost]
        //public IActionResult Update(ProductsSupCatViewModel viewModel)
        //{
        //    Product toUpdate = _productBs.GetById(viewModel.ProductId);

        //    toUpdate.ProductName = viewModel.ProductName;

        //    toUpdate.UnitPrice = (decimal)viewModel.UnitPrice;
        //    toUpdate.UnitsInStock = (short)viewModel.UnitsInStock;

        //    _productBs.Update(toUpdate);

        //    ViewBag.Message = "<div class='alert alert-success'>Ürün Güncellendi</div>";

        //    ProductsSupCatViewModel vm = new ProductsSupCatViewModel();

        //    vm.ProductUpdate = toUpdate;

        //    return Json(new { IsSuccess = true, });

        //}


    }
}

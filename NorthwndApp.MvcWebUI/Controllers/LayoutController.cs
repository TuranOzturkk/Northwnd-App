using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.MvcWebUI.Controllers
{

    public class LayoutController : Controller
    {
        private readonly IProductBs _productBs;
        private readonly IMapper _mapper;

        public LayoutController(IProductBs productBs, IMapper mapper)
        {
            _productBs = productBs;
            _mapper = mapper;    
        }
       
        public IActionResult UrunAra(Product product, string urun)
        {

            if (!string.IsNullOrEmpty(urun))
            {
                return View(_productBs.GetList(x => x.ProductName == urun));

            }
            return View(_productBs.GetList());


        }
           


    }
    
}

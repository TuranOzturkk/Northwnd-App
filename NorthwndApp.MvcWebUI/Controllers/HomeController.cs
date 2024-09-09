using AutoMapper;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Extensions;
using NorthwndApp.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace NorthwndApp.MvcWebUI.Controllers
{

    public class HomeController : Controller
    {
        private readonly IProductBs _productBs;
        private readonly IOrderDetailBs _odBs;
        private readonly IMapper _mapper;
        public HomeController(IProductBs productBs, IOrderDetailBs odBs, IMapper mapper)

        {
            _odBs = odBs;
            _productBs = productBs;
            _mapper = mapper;
        }
       
        public IActionResult Index(string ara)
        {




            if (!string.IsNullOrEmpty(ara))
            {

                string gelenaramailkharfbuyuk = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ara);
                var featuredProducts = _odBs.GetUrun("Product", "Product.ProductPhotos");
               
                //var model = db.Products.ToList();
               
                
                  var arananurunler = featuredProducts.Where(x => x.ProductName.Contains(gelenaramailkharfbuyuk)).ToList();
                    ViewBag.feture = arananurunler;
                    return View("UrunAramaSonuc", arananurunler);
                
               
            }

            return View();

        }
       
        public IActionResult UrunAramaSonuc(string ara)
        {
           
            return View();
        }
    }
}

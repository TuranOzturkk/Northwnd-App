using AutoMapper;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Internal;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Business.Concrete;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Extensions;
using NorthwndApp.MvcWebUI.Models;
using NorthwndApp.MvcWebUI.Statics;
using System;
using System.Collections.Generic;
using TimeZoneConverter;

namespace NorthwndApp.MvcWebUI.ViewComponents
{
    public class YorumGonderViewComponent : ViewComponent
    {
        private readonly IMusterilerBs _musterilerBs;
        private readonly IProductYorumBs _productYorumBs;
        private readonly IProductBs _productBs;
        private readonly IMapper _mapper;
        private readonly IOrderDetailBs _odBs;
        public  YorumGonderViewComponent(IProductBs productBs, IOrderDetailBs odBs, IMapper mapper, IProductYorumBs productYorumBs, IMusterilerBs musterilerBs)
        {
            _productBs = productBs;
            _odBs = odBs;
            _mapper = mapper;
            _productYorumBs = productYorumBs;
            _musterilerBs = musterilerBs;

        }
        public IViewComponentResult Invoke(UrunProductYorumViewModel UrunProductYorumViewModel, int id)
        {

            UrunProductYorumViewModel.Product = _productBs.GetById(id);
            UrunProductYorumViewModel.Musteriler = _musterilerBs.GetById(id);
            UrunProductYorumViewModel.ProductYorum = _productYorumBs.GetById(id);
            UrunProductYorumViewModel.ProductYorumlistesi = _productYorumBs.GetList();
            UrunProductYorumViewModel.Productlistesi = _productBs.GetList();
            UrunProductYorumViewModel.Musterilerlistesi = _musterilerBs.GetList();

            return View(UrunProductYorumViewModel);

        }

        private IViewComponentResult RedirectToAction(string v1, string v2)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public IViewComponentResult YorumOnay(UrunProductYorumViewModel UrunProductYorumViewModel, int id)
        {

            Musteriler loggedInMusteriler = HttpContext.Session.GetObject<Musteriler>("LoggedInUser");
            if (loggedInMusteriler != null)
            {

                ProductYorum yorum = _mapper.Map<ProductYorum>(UrunProductYorumViewModel);
                _productYorumBs.Insert(yorum);

            }
            return View(new { IsSuccess = false, Message = "Giris Yapmalisiniz" });

        }

    }
}

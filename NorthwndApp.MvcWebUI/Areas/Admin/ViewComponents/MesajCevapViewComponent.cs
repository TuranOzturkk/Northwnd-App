using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Areas.Admin.Models;

namespace NorthwndApp.MvcWebUI.Areas.Admin.ViewComponents
{
    public class MesajCevapViewComponent:ViewComponent
    {
        private readonly IIletisimBs _ıletisimBs;
        public MesajCevapViewComponent(IIletisimBs ıletisimBs)
        {
            _ıletisimBs = ıletisimBs;
        }
        public IViewComponentResult Invoke(MesajViewModel MesajViewModel, int id)
        {
          

            return View();
        }
    }
}

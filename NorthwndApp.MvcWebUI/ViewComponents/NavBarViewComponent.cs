using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthwndApp.Business.Abstract;
using NorthwndApp.Model.Dtos;
using NorthwndApp.Model.Entities;
using NorthwndApp.MvcWebUI.Models;
using X.PagedList;

namespace NorthwndApp.MvcWebUI.ViewComponents
{
    public class NavBarViewComponent:ViewComponent
    {
        private readonly ICategoryBs _categoryBs;
        
        public NavBarViewComponent(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
            
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryBs.GetList());
        }

    }
}

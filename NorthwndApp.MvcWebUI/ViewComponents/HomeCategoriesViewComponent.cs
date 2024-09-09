using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;

namespace NorthwndApp.MvcWebUI.ViewComponents
{
    public class HomeCategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryBs _categoryBs;

        public HomeCategoriesViewComponent(ICategoryBs categoryBs)
        {
            _categoryBs = categoryBs;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryBs.GetList(includeList:"Products"));
        }

       
    }
}

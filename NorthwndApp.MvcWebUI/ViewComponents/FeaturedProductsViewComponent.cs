using Microsoft.AspNetCore.Mvc;
using NorthwndApp.Business.Abstract;

namespace NorthwndApp.MvcWebUI.ViewComponents
{
    public class FeaturedProductsViewComponent : ViewComponent
    {
        private readonly IOrderDetailBs _odBs;

        public FeaturedProductsViewComponent(IOrderDetailBs odBs)
        {
            _odBs = odBs;
        }
        public IViewComponentResult Invoke()
        {
        
            var featuredProducts = _odBs.GetFeaturedProducts("Product", "Product.ProductPhotos");
            return View(featuredProducts);
        }
    }
}

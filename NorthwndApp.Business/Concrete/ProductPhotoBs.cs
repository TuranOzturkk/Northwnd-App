using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Concrete
{
    public class ProductPhotoBs : BusinessBase<ProductPhoto>, IProductPhotoBs
    {
        private readonly IProductPhotoRepository _productPhotoRepository;
        public ProductPhotoBs(IProductPhotoRepository productPhotoRepository)
            : base(productPhotoRepository)
        {
            _productPhotoRepository = productPhotoRepository;
        }
    }
}

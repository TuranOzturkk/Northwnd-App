using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Concrete
{
    public class CategoryBs :BusinessBase<Category>, ICategoryBs
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryBs(ICategoryRepository categoryRepository)
            :base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category GetById(int categoryId, params string[] includeList)
        {
            return _categoryRepository.Get(x => x.CategoryId == categoryId, includeList);
        }
    }
}

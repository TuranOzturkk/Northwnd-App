using Infrastructure.DataAccess;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.DataAccess.Abstract
{
    public interface ICategoryRepository : IEntityRepository<Category>
    {
    }
}

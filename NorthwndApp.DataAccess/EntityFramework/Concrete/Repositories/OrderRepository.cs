using Infrastructure.DataAccess.EntityFramework;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories
{
    public class OrderRepository : EntityRepositoryBase<Order, NorthwndContext>, IOrderRepository
    {

    }
}

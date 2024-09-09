using Infrastructure.DataAccess.EntityFramework;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Contexts;
using NorthwndApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories
{
    public class IletisimRepository : EntityRepositoryBase<Iletisim, NorthwndContext>, IIletisimRepository
    {
    
    }
}

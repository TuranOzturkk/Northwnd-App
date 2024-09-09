using NorthwndApp.Business.Abstract;
using NorthwndApp.DataAccess.Abstract;
using NorthwndApp.DataAccess.EntityFramework.Concrete.Repositories;
using NorthwndApp.Model.Entities;

namespace NorthwndApp.Business.Concrete
{
    public class SepetBs : BusinessBase<Sepet>, ISepetBs
    {
        private readonly ISepetRepository _sepetRepository;
        public SepetBs(ISepetRepository sepetRepository)
            : base(sepetRepository)
        {
            _sepetRepository = sepetRepository;
        }


        public Sepet GetById(int SepetID, params string[] includeList)
        {
            return _sepetRepository.Get(x => x.SepetID == SepetID, includeList);
        }

    }
}

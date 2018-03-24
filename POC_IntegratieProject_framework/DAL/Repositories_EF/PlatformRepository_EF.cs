using DAL.Repositories_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PlatformRepository_EF : IPlatformRepository
    {
        private readonly EF.PolitiekeBarometerContext ctx;

        public PlatformRepository_EF()
        {
            ctx = new EF.PolitiekeBarometerContext();
        }

        public PlatformRepository_EF(UnitOfWork uow)
        {
            ctx = uow.Context;
        }
    }
}

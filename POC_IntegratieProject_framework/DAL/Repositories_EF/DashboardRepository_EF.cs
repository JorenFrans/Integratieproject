using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories_EF;
using Domain;

namespace DAL.Repositories
{
    public class DashboardRepository_EF : IDashboardRepository
    {
        private readonly EF.PolitiekeBarometerContext ctx;

        public DashboardRepository_EF()
        {
            ctx = new EF.PolitiekeBarometerContext();
        }

        public DashboardRepository_EF(UnitOfWork uow)
        {
            ctx = uow.Context;
        }

        public List<Alert> getActiveAlerts()
        {
            throw new NotImplementedException();
        }

        public DataConfig getAlertDataConfig(Alert alert)
        {
            throw new NotImplementedException();
        }

        public List<Alert> getAllAlerts()
        {
            throw new NotImplementedException();
        }
    }
}

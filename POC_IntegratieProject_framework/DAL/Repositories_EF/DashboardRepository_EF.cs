﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using Domain;

namespace DAL.Repositories_EF
{
    public class DashboardRepository_EF : IDashboardRepository
    {
        PolitiekeBarometerContext context;

        public DashboardRepository_EF()
        {
            context = new PolitiekeBarometerContext();
        }

        public DashboardRepository_EF(UnitOfWork unitOfWork)
        {
            context = unitOfWork.Context;
        }

        public IEnumerable<Alert> getAllAlerts()
        {
            return  context.Alerts.ToList<Alert>();
        }

        public IEnumerable<Alert> getActiveAlerts()
        {
            return context.Alerts.Where<Alert>(a=>a.Status ==AlertStatus.ACTIEF).ToList<Alert>();
        }

        public DataConfig getAlertDataConfig(Alert alert)
        {
            return context.Alerts.Single<Alert>(a => a.AlertId == alert.AlertId).DataConfig;
        }

       
    }
}

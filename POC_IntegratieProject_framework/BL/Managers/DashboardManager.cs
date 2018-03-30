using BL.Interfaces;
using DAL;
using DAL.Repositories_EF;
using DAL.Repositories_HC;
using Domain;
using Domain.Platformen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Managers
{
    public class DashboardManager : IDashboardManager
    {
        private IDashboardRepository dashboardRepository;

        private UnitOfWorkManager uowManager;

        public DashboardManager()
        {
        }

        public DashboardManager(UnitOfWorkManager uowMgr)
        {
            uowManager = uowMgr;
            dashboardRepository = new DashboardRepository_EF(uowManager.UnitOfWork);
        }


        public List<Alert> getActiveAlerts()
        {
            initNonExistingRepo();
            return dashboardRepository.getActiveAlerts().ToList();
        }

        public DataConfig getAlertDataConfig(Alert alert)
        {
            initNonExistingRepo();
            return alert.DataConfig;
        }

        public Gebruiker getAlertGebruiker(Alert alert)
        {
            initNonExistingRepo();
            return alert.Dashboard.Gebruiker;
        }

        public List<Alert> getAllAlerts()
        {
            initNonExistingRepo();
            return dashboardRepository.getAllAlerts().ToList();
        }


        public void initNonExistingRepo(bool createWithUnitOfWork = false)
        {
            if (dashboardRepository == null)
            {
                if (createWithUnitOfWork)
                {
                    if (uowManager == null)
                    {
                        uowManager = new UnitOfWorkManager();
                    }
                    dashboardRepository = new DashboardRepository_EF(uowManager.UnitOfWork);
                }
                // Als we niet met UoW willen werken, dan maken we een repo aan als die nog niet bestaat.
                else
                {
                    dashboardRepository = new DashboardRepository_EF();
                }

            }



        }
    }
}

﻿using BL.Interfaces;
using DAL;
using DAL.Repositories_HC;
using Domain;
using Domain.Platformen;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Managers
{
    public class DashboardManager : IDashboardManager
    {
        IDashboardRepository dashboardRepository;
        public DashboardManager()
        {
                dashboardRepository = new DashboardRepository_HC();
        }

        public List<Alert> getActiveAlerts()
        {
            return dashboardRepository.getActiveAlerts();
        }

        public DataConfig getAlertDataConfig(Alert alert)
        {
            return alert.DataConfig;
        }

        public Gebruiker getAlertGebruiker(Alert alert)
        {
            return alert.Dashboard.Gebruiker;
        }

    }
}

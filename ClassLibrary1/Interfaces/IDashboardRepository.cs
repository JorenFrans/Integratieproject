using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDashboardRepository
    {
        
        List<Alert> getActiveAlerts();

        DataConfig getAlertDataConfig(Alert alert);
    }
}

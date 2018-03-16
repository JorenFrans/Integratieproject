using Domain.Platformen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dashboards
{
    public class Dashboard
    {
        public int DashboardId { get; set; }

        public Gebruiker Gebruiker{ get; set; }
    }
}

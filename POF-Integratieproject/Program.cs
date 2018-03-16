using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.BL;

namespace POF_Integratieproject {
    class Program {
        private static readonly IDashboardManager dashboardManager = new DashboardManager();
        private static readonly IPostManager postManager = new PostManager();

        static void Main(string[] args) {

            while (!quit)
                ShowMenu();
        }
    }
}

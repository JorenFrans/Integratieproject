using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.EF
{
    internal class PolitiekeBarometerConfiguration : DbConfiguration
    {
        public PolitiekeBarometerConfiguration()
        {
           
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory()); 

            this.SetProviderServices("System.Data.SqlClient", System.Data.Entity.SqlServer.SqlProviderServices.Instance);

        }
    }
}

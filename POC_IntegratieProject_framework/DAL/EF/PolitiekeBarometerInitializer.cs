using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
namespace DAL.EF
{
    class PolitiekeBarometerInitializer : DropCreateDatabaseIfModelChanges<PolitiekeBarometerContext>
    {
        protected override void Seed(PolitiekeBarometerContext context)
        {
            base.Seed(context);
        }
    }
}

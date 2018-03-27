using Domain;
using Domain.Elementen;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.EF
{
    [DbConfigurationType(typeof(PolitiekeBarometerConfiguration))]
    class PolitiekeBarometerContext : DbContext
    {

        private readonly bool delaySave;
        public PolitiekeBarometerContext(bool unitOfWorkPresent = false) : base("Politieke_BarometerDB")
        {
            Database.SetInitializer<PolitiekeBarometerContext>(new PolitiekeBarometerInitializer());
            delaySave = unitOfWorkPresent;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relaties

        }


        //Alerts
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<DataConfig> DataConfigs { get; set; }

        //Elementen
        public DbSet<Element> Elementen { get; set; }
        public DbSet<Keyword> Keywords { get; set; }

        //Platformen
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Thema> Themas { get; set; }

        //Posts
        public DbSet<Post> Posts { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Waarde> Waardes { get; set; }

        public override int SaveChanges()
        {
            if (delaySave)
            {
                return -1;
            }
            return base.SaveChanges();
        }

        internal int CommitChanges()
        {
            if (delaySave)
            {
                return base.SaveChanges();
            }
            throw new InvalidOperationException("Geen UnitOfWork, gebruik SaveChanges");
        }
    }
}

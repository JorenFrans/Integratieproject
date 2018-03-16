using Domain;
using Domain.Elementen;
using Domain.Posts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.EF
{
    [DbConfigurationType(typeof(PolitiekeBarometerConfiguration))]
    class PolitiekeBarometerContext : DbContext
    {
        public PolitiekeBarometerContext() : base("Politieke_BarometerDB")
        {
        }

        public DbSet<Alert> Alerts { get; set; }
        public DbSet<DataConfig> DataConfigs { get; set; }

        public DbSet<Element> Elementen { get; set; }
        public DbSet<ThemaKeyword> Keywords { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Thema> Themas { get; set; }
        public DbSet<ThemaKeyword> ThemaKeywords { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostKeyword> PostKeywords { get; set; }
        public DbSet<Parameter> Parameters { get; set; }
        public DbSet<Waarde> Waardes { get; set; }

    }
}

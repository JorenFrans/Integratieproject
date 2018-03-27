using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using Domain;
using Domain.Dashboards;
using System.Linq;
using Domain.Elementen;

namespace DAL.EF
{
    class PolitiekeBarometerInitializer : DropCreateDatabaseAlways<PolitiekeBarometerContext>
    {
        protected override void Seed(PolitiekeBarometerContext context)
        {
            addElementen(context);
            addDataConfigs(context);
           // addAlerts(context);
            base.Seed(context);
        }
        private void addDataConfigs(PolitiekeBarometerContext context)
        {
            DataConfig dataConfig1 = new DataConfig
            {
                DataConfiguratieId = 0,
                DataType = DataType.TOTAAL,
                Element = new Persoon()
                {
                    Naam = "Imade Annouri"
                }
            };

            DataConfig dataConfig2 = new DataConfig
            {
                DataType = DataType.TOTAAL,
                Element = new Organisatie()
                {
                    Naam = "GROEN"
                }
            };

            DataConfig dataConfig3 = new DataConfig
            {
                DataType = DataType.TOTAAL,
                Element = new Thema()
                {
                    Naam = "Cultuur"
                }
            };

            DataConfig dataConfig4 = new DataConfig
            {
                DataType = DataType.TREND,
                Element = new Persoon()
                {
                    Naam = "Imade Annouri"
                }
            };
            context.DataConfigs.Add(dataConfig1);
            context.DataConfigs.Add(dataConfig2);
            context.DataConfigs.Add(dataConfig3);
            context.DataConfigs.Add(dataConfig4);

            Alert alert1 = new Alert
            {
                ApplicatieMelding = true,
                BrowserMelding = true,
                EmailMelding = true,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfig1,
                Dashboard = new Dashboard
                {
                    DashboardId = 1,
                    Gebruiker = new Domain.Platformen.Gebruiker
                    {
                        Email = "sam.claessen@student.kdg.be",
                        Naam = "Sam Claessen",
                        GebruikerId = 1,
                        Wachtwoord = "wachtwoord"
                    }
                }
            };

            Alert alert2 = new Alert
            {
                ApplicatieMelding = true,
                BrowserMelding = true,
                EmailMelding = true,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfig2,
                Dashboard = new Dashboard
                {
                    DashboardId = 1,
                    Gebruiker = new Domain.Platformen.Gebruiker
                    {
                        Email = "sam.claessen@student.kdg.be",
                        Naam = "Sam Claessen",
                        GebruikerId = 1,
                        Wachtwoord = "wachtwoord"
                    }
                }
            };
            Alert alert3 = new Alert
            {
                ApplicatieMelding = false,
                BrowserMelding = true,
                EmailMelding = false,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfig3,
                Dashboard = new Dashboard
                {
                    DashboardId = 2,
                    Gebruiker = new Domain.Platformen.Gebruiker
                    {
                        Email = "thomas.somers@student.kdg.be",
                        Naam = "Thomas Somers",
                        GebruikerId = 2,
                        Wachtwoord = "wachtwoord"
                    }
                }
            };

            Alert alert4 = new Alert
            {
                ApplicatieMelding = false,
                BrowserMelding = false,
                EmailMelding = true,
                Waarde = -4,
                Operator = ">",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfig4,
                Dashboard = new Dashboard
                {
                    DashboardId = 2,
                    Gebruiker = new Domain.Platformen.Gebruiker
                    {
                        Email = "thomas.somers@student.kdg.be",
                        Naam = "Thomas Somers",
                        GebruikerId = 2,
                        Wachtwoord = "wachtwoord"
                    }
                }
            };
            Alert alert5 = new Alert
            {
                ApplicatieMelding = true,
                BrowserMelding = false,
                EmailMelding = false,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.INACTIEF,
                DataConfig = dataConfig1,
                Dashboard = new Dashboard
                {
                    DashboardId = 2,
                    Gebruiker = new Domain.Platformen.Gebruiker
                    {
                        Email = "thomas.somers@student.kdg.be",
                        Naam = "Thomas Somers",
                        GebruikerId = 2,
                        Wachtwoord = "wachtwoord"
                    }
                }
            };
            context.Alerts.Add(alert1);
            context.Alerts.Add(alert2);
            context.Alerts.Add(alert3);
            context.Alerts.Add(alert4);
            context.Alerts.Add(alert5);
            context.SaveChanges();
        }
             
        private void addElementen(PolitiekeBarometerContext context)
        {
            addKeywords(context);
            addOrganisaties(context);
            addPersonen(context);
            addThemas(context);
        }
        private void addOrganisaties(PolitiekeBarometerContext context)
        {
            Element organisatie1 = new Organisatie()
            {
                Naam = "NVA",
            };
            Element organisatie2 = new Organisatie()
            {
                Naam = "GROEN",
            };
            context.Elementen.Add(organisatie1);
            context.Elementen.Add(organisatie2);
            context.SaveChanges();
        }
        private void addPersonen(PolitiekeBarometerContext context)
        {
            Element persoon1 = new Persoon()
            {
                Naam = "Imade Annouri",
                Organisatie = (Organisatie)context.Elementen.Single<Element>(e => e.Naam == "NVA")
            };

            Element persoon2 = new Persoon()
            {
                Naam = "Caroline Bastiaens",
                Organisatie = (Organisatie)context.Elementen.Single<Element>(e => e.Naam == "GROEN")
            };
            Element persoon3 = new Persoon()
            {
                Naam = "Vera Celis",
                Organisatie = (Organisatie)context.Elementen.Single<Element>(e => e.Naam == "GROEN")
            };
            context.Elementen.Add(persoon1);
            context.Elementen.Add(persoon2);
            context.Elementen.Add(persoon3);
            context.SaveChanges();
        }
        private void addThemas(PolitiekeBarometerContext context)
        {
            Keyword keyword = context.Keywords.Single<Keyword>(kw => kw.KeywordNaam == "moslimouders");

            Element thema1 = new Thema()
            {
                Naam = "Cultuur",
                Keywords = new List<Keyword>()
                {
                    keyword
                }
            };
            keyword.Themas.Add((Thema)thema1);
            context.Keywords.Add(keyword);
            context.Elementen.Add(thema1);
            context.SaveChanges();
        }
        private void addKeywords(PolitiekeBarometerContext context)
        {
            Keyword keyword1 = new Keyword()
            {
                KeywordNaam = "moslimouders",
                Themas = new List<Thema>()
            };
            context.Keywords.Add(keyword1);
            context.SaveChanges();
        }
    }
}

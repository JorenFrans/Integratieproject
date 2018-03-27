using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using Domain;
using Domain.Dashboards;
using System.Linq;
using Domain.Elementen;
using Domain.Platformen;

namespace DAL.EF
{
    class PolitiekeBarometerInitializer : DropCreateDatabaseAlways<PolitiekeBarometerContext>
    {
        protected override void Seed(PolitiekeBarometerContext context)
        {
<<<<<<< HEAD
            #region DataConfigs
=======
            addElementen(context);
            addDataConfigs(context);
           // addAlerts(context);
            base.Seed(context);
        }
        private void addDataConfigs(PolitiekeBarometerContext context)
        {
>>>>>>> 22c6582408f398b88e0d8488201079f3244f6066
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
<<<<<<< HEAD
            #endregion

            #region Gebruikers

            Gebruiker gebruiker1 = new Gebruiker()
            {
                Email = "sam.claessen@student.kdg.be",
                Naam = "Sam Claessen",
                GebruikerId = 1,
                Wachtwoord = "wachtwoord"
            };

            Gebruiker gebruiker2 = new Domain.Platformen.Gebruiker
            {
                Email = "thomas.somers@student.kdg.be",
                Naam = "Thomas Somers",
                GebruikerId = 2,
                Wachtwoord = "123"
            };
            #endregion

            #region Dashboard

            Dashboard dashboard1 = new Dashboard()
            {
                Gebruiker = gebruiker1
            };

            Dashboard dashboard2 = new Dashboard()
            {
                Gebruiker = gebruiker2
            };
            #endregion

            #region Alerts
=======
            context.DataConfigs.Add(dataConfig1);
            context.DataConfigs.Add(dataConfig2);
            context.DataConfigs.Add(dataConfig3);
            context.DataConfigs.Add(dataConfig4);

>>>>>>> 22c6582408f398b88e0d8488201079f3244f6066
            Alert alert1 = new Alert
            {
                ApplicatieMelding = true,
                BrowserMelding = true,
                EmailMelding = true,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfig1,
<<<<<<< HEAD
                Dashboard = dashboard1
=======
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
>>>>>>> 22c6582408f398b88e0d8488201079f3244f6066
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
<<<<<<< HEAD
                Dashboard = dashboard1
=======
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
>>>>>>> 22c6582408f398b88e0d8488201079f3244f6066
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
<<<<<<< HEAD
                Dashboard = dashboard2
=======
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
>>>>>>> 22c6582408f398b88e0d8488201079f3244f6066
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
<<<<<<< HEAD
                Dashboard = dashboard2
=======
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
>>>>>>> 22c6582408f398b88e0d8488201079f3244f6066
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
<<<<<<< HEAD
                Dashboard = dashboard2
            };
            #endregion

            #region Organisatie
            Organisatie organisatie1 = new Organisatie()
=======
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
>>>>>>> 22c6582408f398b88e0d8488201079f3244f6066
            {
                Naam = "NVA",
                Personen = new List<Persoon>()
            };
            Organisatie organisatie2 = new Organisatie()
            {
                Naam = "GROEN",
                Personen = new List<Persoon>()
            };
            #endregion

            #region Personen
            Persoon persoon1 = new Persoon()
            {
                Naam = "Imade Annouri",
                Organisatie = organisatie1
            };

            Persoon persoon2 = new Persoon()
            {
                Naam = "Caroline Bastiaens",
                Organisatie = organisatie2
            };
            Persoon persoon3 = new Persoon()
            {
                Naam = "Vera Celis",
                Organisatie = organisatie2
            };

            organisatie1.Personen.Add(persoon1);
            organisatie2.Personen.Add(persoon2);
            organisatie2.Personen.Add(persoon3);
            #endregion

            #region Keywords
            Keyword keyword1 = new Keyword()
            {
                KeywordNaam = "moslimouders",
                Themas = new List<Thema>()
            };
            #endregion

            #region Themas
            Element thema1 = new Thema()
            {
                Naam = "Cultuur",
                Keywords = new List<Keyword>()
                {
                    keyword1
                }
            };
            keyword1.Themas.Add((Thema)thema1);
            #endregion

            #region AddToDB

            #region AddPlatformen
            #region AddGebruikers
            context.Gebruikers.Add(gebruiker1);
            context.Gebruikers.Add(gebruiker2);
            #endregion
            #region addDashboards
            context.Dashboards.Add(dashboard1);
            context.Dashboards.Add(dashboard2);
            #endregion
            #endregion

            #region AddDashboard
            #region AddDataConfigs
            context.DataConfigs.Add(dataConfig1);
            context.DataConfigs.Add(dataConfig2);
            context.DataConfigs.Add(dataConfig3);
            context.DataConfigs.Add(dataConfig4);
            #endregion

            #region AddAlerts
            context.Alerts.Add(alert1);
            context.Alerts.Add(alert2);
            context.Alerts.Add(alert3);
            context.Alerts.Add(alert4);
            context.Alerts.Add(alert5);
            #endregion
            #endregion


            #region AddElementen

            #region AddKeywords
            context.Keywords.Add(keyword1);
            #endregion

            #region AddOrganisaties
            context.Elementen.Add(organisatie1);
            context.Elementen.Add(organisatie2);
            #endregion

            #region AddPersonen
            context.Elementen.Add(persoon1);
            context.Elementen.Add(persoon2);
            context.Elementen.Add(persoon3);
            #endregion

            #region AddThemas
            context.Elementen.Add(thema1);
            #endregion
            #endregion
            #endregion

            base.Seed(context);
        }
    }
}

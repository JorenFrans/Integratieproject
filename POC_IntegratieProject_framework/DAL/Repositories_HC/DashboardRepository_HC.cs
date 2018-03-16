using Domain;
using Domain.Dashboards;
using Domain.Elementen;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories_HC
{
    public class DashboardRepository_HC : IDashboardRepository
    {
        List<Alert> alerts = new List<Alert>();
        List<DataConfig> dataConfigs = new List<DataConfig>();

        public DashboardRepository_HC()
        {
            seed();
        }

        private void seed()
        {
            addDataConfigs();
            addAlerts();
        }

        public List<Alert> getActiveAlerts()
        {
            return this.alerts.FindAll(a => a.Status == AlertStatus.ACTIEF);
        }

        public DataConfig getAlertDataConfig(Alert alert)
        {
            return alert.DataConfig;
        }

        private void addAlerts()
        {
            Alert alert1 = new Alert
            {
                AlertId = alerts.Count,
                ApplicatieMelding = true,
                BrowserMelding = true,
                EmailMelding = true,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfigs.Find(dc => dc.DataConfiguratieId == 0),
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
            alerts.Add(alert1);

            Alert alert2 = new Alert
            {
                AlertId = alerts.Count,
                ApplicatieMelding = true,
                BrowserMelding = true,
                EmailMelding = true,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfigs.Find(dc => dc.DataConfiguratieId == 1),
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
            alerts.Add(alert2);
            Alert alert3 = new Alert
            {
                AlertId = alerts.Count,
                ApplicatieMelding = false,
                BrowserMelding = true,
                EmailMelding = false,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfigs.Find(dc => dc.DataConfiguratieId == 2),
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
            alerts.Add(alert3);

            Alert alert4 = new Alert
            {
                AlertId = alerts.Count,
                ApplicatieMelding = false,
                BrowserMelding = false,
                EmailMelding = true,
                Waarde = -4,
                Operator = ">",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfigs.Find(dc => dc.DataConfiguratieId == 3),
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
            alerts.Add(alert4);
            Alert alert5 = new Alert
            {
                AlertId = alerts.Count,
                ApplicatieMelding = true,
                BrowserMelding = false,
                EmailMelding = false,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.INACTIEF,
                DataConfig = dataConfigs.Find(dc => dc.DataConfiguratieId == 0),
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
            alerts.Add(alert5);
        }

        private void addDataConfigs()
        {
            DataConfig dataConfig1 = new DataConfig
            {
                DataConfiguratieId = dataConfigs.Count,
                DataType = DataType.TOTAAL,
                Element = new Persoon()
                {
                    Naam = "Imade Annouri"
                }
            };
            dataConfigs.Add(dataConfig1);

            DataConfig dataConfig2 = new DataConfig
            {
                DataConfiguratieId = dataConfigs.Count,
                DataType = DataType.TOTAAL,
                Element = new Organisatie()
                {
                    Naam = "GROEN"
                }
            };
            dataConfigs.Add(dataConfig2);

            DataConfig dataConfig3 = new DataConfig
            {
                DataConfiguratieId = dataConfigs.Count,
                DataType = DataType.TOTAAL,
                Element = new Thema()
                {
                    Naam = "Cultuur"
                }
            };
            dataConfigs.Add(dataConfig3);

            DataConfig dataConfig4 = new DataConfig
            {
                DataConfiguratieId = dataConfigs.Count,
                DataType = DataType.TREND,
                Element = new Persoon()
                {
                    Naam = "Imade Annouri"
                }
            };
            dataConfigs.Add(dataConfig4);

        }

        public List<Alert> getAllAlerts()
        {
            return alerts;
        }
    }
}

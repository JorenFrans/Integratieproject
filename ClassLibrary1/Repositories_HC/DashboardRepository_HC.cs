using Domain;
using Domain.Dashboards;
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
                AlertId = 1,
                ApplicatieMelding = true,
                BrowserMelding = false,
                EmailMelding = true,
                Waarde = 2,
                Operator = ">",
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
            alerts.Add(alert1);

            Alert alert2 = new Alert
            {
                AlertId = 2,
                ApplicatieMelding = true,
                BrowserMelding = false,
                EmailMelding = true,
                Waarde = 2,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfigs.Find(dc => dc.DataConfiguratieId == 2),
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
                AlertId = 2,
                ApplicatieMelding = true,
                BrowserMelding = false,
                EmailMelding = true,
                Waarde = 50,
                Operator = "<",
                Status = AlertStatus.ACTIEF,
                DataConfig = dataConfigs.Find(dc => dc.DataConfiguratieId == 3),
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
            alerts.Add(alert3);
        }

        private void addDataConfigs()
        {
            DataConfig dataConfig1 = new DataConfig
            {
                DataConfiguratieId = 1,
                DataType = DataType.TOTAAL,
                Element = new Organisatie()
                {
                    Id = 1,
                    Naam = "NVA",
                }
            };
            dataConfigs.Add(dataConfig1);

            DataConfig dataConfig2 = new DataConfig
            {
                DataConfiguratieId = 2,
                DataType = DataType.TOTAAL,
                Element = new Persoon()
                {
                    Id = 2,
                    Naam = "Bart de Wever",
                    Organisatie = new Organisatie()
                    {
                        Id = 1,
                        Naam = "NVA",
                    }
                }
            };
            dataConfigs.Add(dataConfig2);
            DataConfig dataConfig3 = new DataConfig
            {
                DataConfiguratieId = 3,
                DataType = DataType.TOTAAL,
                Element = new Persoon()
                {
                    Id = 4,
                    Naam ="Imade Annouri"	,

                    Organisatie = new Organisatie()
                    {
                        Id = 1,
                        Naam = "NVA",
                    }
                }
            };
            dataConfigs.Add(dataConfig3);
        }
    }
}

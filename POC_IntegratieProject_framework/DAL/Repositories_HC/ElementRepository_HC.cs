using Domain;
using Domain.Elementen;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories_HC
{
    public class ElementRepository_HC : IElementRepository
    {
        List<Element> elementen = new List<Element>();
        List<ThemaKeyword> keywords = new List<ThemaKeyword>();
        public ElementRepository_HC()
        {
            addKeywords();
            addElementen();
        }

        private void addKeywords()
        {
            ThemaKeyword keyword1 = new ThemaKeyword()
            {
                Keyword = "moslimouders",
                Thema = (Thema)elementen.Find(t => t.Naam == "Cultuur")
            };
            keywords.Add(keyword1);

        }

        private void addElementen()
        {
            addOrganisaties();
            addPersonen();
            addThemas();
        }
        private void addOrganisaties()
        {
            Element organisatie1 = new Organisatie()
            {
                Id = elementen.Count,
                Naam = "NVA",
            };
            elementen.Add(organisatie1);
            Element organisatie2 = new Organisatie()
            {
                Id = elementen.Count,
                Naam = "GROEN",
            };
            elementen.Add(organisatie2);
        }
        private void addPersonen()
        {
            Element persoon1 = new Persoon()
            {
                Id = elementen.Count,
                Naam = "Imade Annouri",
                Organisatie = (Organisatie)elementen.Find(e => e.Naam == "NVA")
            };
            elementen.Add(persoon1);

            Element persoon2 = new Persoon()
            {
                Id = elementen.Count,
                Naam = "Caroline Bastiaens",
                Organisatie = (Organisatie)elementen.Find(e => e.Naam == "GROEN")
            };
            elementen.Add(persoon2);
            Element persoon3 = new Persoon()
            {
                Id = elementen.Count,
                Naam = "Vera Celis",
                Organisatie = (Organisatie)elementen.Find(e => e.Naam == "GROEN")
            };
            elementen.Add(persoon3);

        }
        private void addThemas()
        {
            Element thema1 = new Thema()
            {
                Id = elementen.Count,
                Naam = "Cultuur",
                Keywords = new List<ThemaKeyword>()
                {
                    keywords.Find(kw=>kw.Keyword=="moslimouders"),
                }
            };
            elementen.Add(thema1);
        }

        public Element getElementByID(int elementId)
        {
            return elementen.Find(e => e.Id == elementId);
        }

        public Element getElementByName(string naam)
        {
            Element element = elementen.Find(e => e.Naam == naam);

            return element;
        }

        public List<Element> getAllElementen()
        {
            return elementen;
        }

        public Element AddPersoon(string naam)
        {
            Element element = new Persoon()
            {
                Id = elementen.Count,
                Naam = naam,
                Organisatie = new Organisatie()
                {

                }
            };
            elementen.Add(element);
            return element;
        }
    }
}

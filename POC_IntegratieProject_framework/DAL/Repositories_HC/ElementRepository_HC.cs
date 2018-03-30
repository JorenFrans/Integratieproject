using Domain;
using Domain.Elementen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories_HC
{
    public class ElementRepository_HC : IElementRepository
    {
        List<Element> elementen = new List<Element>();
        List<Keyword> keywords = new List<Keyword>();
        public ElementRepository_HC()
        {
            addKeywords();
            addElementen();
        }

        private void addKeywords()
        {
            Keyword keyword1 = new Keyword()
            {
                KeywordNaam = "moslimouders",
                Themas = new List<Thema>()
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
            Thema thema1 = new Thema()
            {
                Id = elementen.Count,
                Naam = "Cultuur",
                Keywords = new List<Keyword>()
            };
            Keyword keyword = keywords.Single(kw => kw.KeywordId == 0);
            thema1.Keywords.Add(keyword);
            keyword.Themas.Add(thema1);
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

        public IEnumerable<Element> getAllElementen()
        {
            return elementen;
        }

        public void AddPersoon(Persoon persoon)
        {
            Element element = new Persoon()
            {
                Id = elementen.Count,
                Naam = persoon.Naam,
                Organisatie = persoon.Organisatie
            };
            elementen.Add(element);
        }

        public Thema GetThemaByName(string naam)
        {
            throw new NotImplementedException();
        }

        public Thema GetThemaById(int id)
        {
            throw new NotImplementedException();
        }

        public Organisatie GetOrganisatieByName(string naam)
        {
            throw new NotImplementedException();
        }

        public Organisatie GetOrganisatieById(int id)
        {
            throw new NotImplementedException();
        }

        public Persoon GetPersoonByName(string naam)
        {
            throw new NotImplementedException();
        }

        public Persoon GetPersoonById(int id)
        {
            throw new NotImplementedException();
        }

        public Persoon GetElementById(int id, Type type)
        {
            throw new NotImplementedException();
        }

        public Persoon GetElementByNaam(string naam, Type type)
        {
            throw new NotImplementedException();
        }

        Element IElementRepository.GetElementById(int id, Type type)
        {
            throw new NotImplementedException();
        }

        Element IElementRepository.GetElementByNaam(string naam, Type type)
        {
            throw new NotImplementedException();
        }
    }
}

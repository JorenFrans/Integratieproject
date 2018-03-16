using Domain;
using Domain.Elementen;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories_HC
{
    public class ElementRepository_HC : IElementRepository
    {
        List<Element> elementen;

        public ElementRepository_HC()
        {
            elementen = new List<Element>();
            addElementen();
        }

        private void addElementen()
        {
            Element element1 = new Organisatie()
            {
                Id = 1,
                Naam = "NVA",
            };
            elementen.Add(element1);

            Element element2 = new Persoon()
            {
                Id = 2,
                Naam = "Bart de Wever",
                Organisatie = (Organisatie)getElementByID(1)
            };
            elementen.Add(element2);
            Element element3 = new Thema()
            {
                Id = 3,
                Naam = "Mobiliteit",
                Keywords = new List<ThemaKeyword>()
            };
            elementen.Add(element3);
        }

        public Element getElementByID(int elementId)
        {
            return elementen.Find(e => e.Id == elementId);
        }

        public Persoon getElementByName(string naam)
        {
            Persoon persoon = (Persoon)elementen.Find(e => e.Naam == naam);
            if (persoon == null)
            {
                persoon = new Persoon()
                {
                    Naam = naam,
                    Id = elementen.Count+1,
                    Organisatie = new Organisatie() { }
                };
            }
            return persoon;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using Domain;

namespace DAL.Repositories_EF
{
    public class ElementRepository_EF : IElementRepository
    {
        PolitiekeBarometerContext context;

        public ElementRepository_EF()
        {
            context = new PolitiekeBarometerContext();
        }
        public ElementRepository_EF(UnitOfWork unitOfWork)
        {
            context = unitOfWork.Context;
        }
        public void AddPersoon(Persoon persoon)
        {
            context.Personen.Add(persoon);
            context.SaveChanges();
        }

        public IEnumerable<Element> getAllElementen()
        {
            List<Element> elementen = new List<Element>();
            elementen = context.Elementen.ToList<Element>();
            return elementen;
        }

        public Element getElementByID(int elementId)
        {
            return context.Elementen.Single<Element>(e => e.Id == elementId);
        }

        public Element getElementByName(string naam)
        {
            return context.Elementen.Single<Element>(e => e.Naam == naam);
        }
    }
}

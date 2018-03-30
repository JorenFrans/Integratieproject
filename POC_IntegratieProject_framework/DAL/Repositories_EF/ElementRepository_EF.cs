using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using Domain;
using Domain.Elementen;

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
            elementen.AddRange(context.Themas);
            elementen.AddRange(context.Personen);
            elementen.AddRange(context.Organisaties);
            return elementen;
        }
        public Element GetElementById(int id, Type type)
        {
            if (type.Equals(typeof(Thema)))
            {
                return GetThemaById(id);
            }
            else if (type.Equals(typeof(Organisatie)))
            {
                return GetOrganisatieById(id);
            }
            else if (type.Equals(typeof(Persoon)))
            {
                return GetPersoonById(id);
            }
            return null;
        }
        public Element GetElementByNaam(string naam, Type type)
        {
            if (type.Equals(typeof(Thema)))
            {
                return GetThemaByName(naam);
            }
            else if (type.Equals(typeof(Organisatie)))
            {
                return GetOrganisatieByName(naam);
            }
            else if (type.Equals(typeof(Persoon)))
            {
                return GetPersoonByName(naam);
            }
            return null;
        }
        public Organisatie GetOrganisatieById(int id)
        {
            return context.Organisaties.Single(o => o.Id == id);
        }

        public Organisatie GetOrganisatieByName(string naam)
        {
            return context.Organisaties.Single(o => o.Naam == naam);
        }

        public Persoon GetPersoonById(int id)
        {
            return context.Personen.Single(o => o.Id == id);
        }

        public Persoon GetPersoonByName(string naam)
        {
            return context.Personen.Single(o => o.Naam == naam);
        }

        public Thema GetThemaById(int id)
        {
            return context.Themas.Single(o => o.Id == id);
        }

        public Thema GetThemaByName(string naam)
        {
            return context.Themas.Single(o => o.Naam == naam);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories_EF;
using Domain;

namespace DAL.Repositories
{
    public class ElementRepository_EF : IElementRepository
    {
        private readonly EF.PolitiekeBarometerContext ctx;

        public ElementRepository_EF()
        {
            ctx = new EF.PolitiekeBarometerContext();
        }

        public ElementRepository_EF(UnitOfWork uow)
        {
            ctx = uow.Context;
        }

        public Element AddPersoon(string naam)
        {
            throw new NotImplementedException();
        }

        public List<Element> getAllElementen()
        {
            throw new NotImplementedException();
        }

        public Element getElementByID(int elementId)
        {
            throw new NotImplementedException();
        }

        public Element getElementByName(string naam)
        {
            throw new NotImplementedException();
        }
    }
}

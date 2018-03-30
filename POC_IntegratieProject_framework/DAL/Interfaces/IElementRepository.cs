using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IElementRepository
    {
        Thema GetThemaByName(string naam);
        Thema GetThemaById(int id);

        Organisatie GetOrganisatieByName(string naam);
        Organisatie GetOrganisatieById(int id);

        Persoon GetPersoonByName(string naam);
        Persoon GetPersoonById(int id);

        Element GetElementById(int id, Type type);
        Element GetElementByNaam(string naam, Type type);

        IEnumerable<Element> getAllElementen();
        void AddPersoon(Persoon persoon);
    }
}

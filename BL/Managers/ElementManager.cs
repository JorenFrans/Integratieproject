using BL.Interfaces;
using DAL;
using DAL.Repositories_HC;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Managers
{
    public class ElementManager : IElementManager
    {
        IElementRepository elementRepository = new ElementRepository_HC();

        public Persoon getPersoon(string naam)
        {
            return elementRepository.getElementByName(naam);
        }
    }
}

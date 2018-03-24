using BL.Interfaces;
using DAL;
using DAL.Repositories;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Managers
{
    public class ElementManager : IElementManager
    {
        IElementRepository elementRepository = new  ElementRepository_EF();

        public List<Element> getAllElementen()
        {
            return elementRepository.getAllElementen();
        }

        public Element getElementByNaam(string naam)
        {
            Element element = elementRepository.getElementByName(naam);

            if (element == null)
            {
                element = elementRepository.AddPersoon(naam);
            }

            return element;
        }
    }
}

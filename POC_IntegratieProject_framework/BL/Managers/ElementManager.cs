﻿using BL.Interfaces;
using DAL;
using DAL.Repositories_EF;
using DAL.Repositories_HC;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Managers
{
    public class ElementManager : IElementManager
    {
        IElementRepository elementRepository = new ElementRepository_HC();

        public List<Element> getAllElementen()
        {
            return elementRepository.getAllElementen().ToList();
        }

        public Element getElementByNaam(string naam)
        {
            Element element = elementRepository.getElementByName(naam);

            if (element == null)
            {
                element = new Persoon()
                {
                    Naam = naam
                };
                elementRepository.AddPersoon((Persoon) element);
            }
            return element;
        }
    }
}

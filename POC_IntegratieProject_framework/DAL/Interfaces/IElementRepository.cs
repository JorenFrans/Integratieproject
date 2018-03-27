﻿using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IElementRepository
    {
        Element getElementByID(int elementId);
        Element getElementByName(string naam);
        IEnumerable<Element> getAllElementen();
        void AddPersoon(Persoon persoon);
    }
}

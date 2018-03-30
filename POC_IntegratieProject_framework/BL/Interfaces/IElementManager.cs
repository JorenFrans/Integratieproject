using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace BL.Interfaces
{
    public interface IElementManager
    {
        Element getElementByNaam(string naam, Type type);
        List<Element> getAllElementen();
    }
}

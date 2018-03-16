using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace BL.Interfaces
{
    public interface IElementManager
    {
        Persoon getPersoon(string naam);
    }
}

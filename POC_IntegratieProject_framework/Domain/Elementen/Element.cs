using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class Element
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }

        public override bool Equals(object obj)
        {
            var element = obj as Element;
            return element != null &&
                   Id == element.Id &&
                   Naam == element.Naam;
        }
    }
}


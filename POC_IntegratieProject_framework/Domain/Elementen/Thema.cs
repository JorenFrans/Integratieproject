using Domain.Elementen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Thema : Element
    {
        public List<Keyword> Keywords { get; set; }

        public override bool Equals(object obj)
        {
            var thema = obj as Thema;
            return thema != null &&
                   base.Equals(obj);
        }
    }
}

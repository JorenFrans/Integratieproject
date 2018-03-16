using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Elementen
{
    public class ThemaKeyword
    {
        [Key]
        public int ThemaKeywordId { get; set; }
        [Required]
        public string Keyword { get; set; }
        [Required]
        public Thema Thema { get; set; }
    }
}

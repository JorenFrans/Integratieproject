using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain {
    public class Waarde {
        [Key]
        public int WaardeId { get; set; }
        [Required]
        public String Value { get; set; }

        [Required]
        public Parameter Parameter{ get; set; }
    }
}

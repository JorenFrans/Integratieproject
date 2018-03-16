using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Posts
{
    public class PostKeyword
    {
        [Key]
        public int PostKeywordId { get; set; }

        [Required]
        public Post Post { get; set; }

        public string word { get; set; }

    }
}

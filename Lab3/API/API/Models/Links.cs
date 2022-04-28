using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Models
{
    public class Links
    {
        public int LinksId { get; set; }
        public string WebLink { get; set; }

        public ICollection<IntresseLinks> IntresseLinks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Models
{
    public class IntresseLinks
    {
        public int IntresseLinksId { get; set; }
        public int IntresseId { get; set; }

        public Intresse Intresse { get; set; }
        public Links Links { get; set; }
    }
}

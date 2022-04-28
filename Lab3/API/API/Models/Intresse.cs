using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace API.Models
{
    public class Intresse
    {



        public int IntresseId { get; set; }
        public string Titel { get; set; }
        public string Description { get; set; }
        public ICollection<PersonIntresse> PersonIntresse { get; set; }

        public ICollection<IntresseLinks> IntresseLinks { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace API.Models
{
    public class PersonIntresse
    {
        public int PersonIntresseId { get; set; }
        public int PersonId { get; set; }
        public int IntresseId { get; set; }

        public Person person { get; set; }
        public Intresse Intresse { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace API.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Telefonnumber { get; set; }   

        public ICollection<PersonIntresse> PersonIntresse { get; set; }
    }
}

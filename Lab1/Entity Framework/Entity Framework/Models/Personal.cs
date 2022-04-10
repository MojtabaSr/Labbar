using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity_Framework.Models
{
    public class Personal
    {
        [Key]
        public int PersonalId { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public List<Ledighet> Ledighet { get; set; }

    }
}

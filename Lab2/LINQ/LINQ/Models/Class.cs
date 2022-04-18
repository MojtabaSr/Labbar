using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LINQ.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Student> Student { get; set; }
    }
}

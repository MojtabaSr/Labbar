
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50, MinimumLength =16, ErrorMessage = "Part {0} must be between {2} and {1} character(s) in length.")]
        public string Name { get; set; }
        public string MobileNumber { get; set; }   
        public int Age { get; set; }

        public List<Book> books { get; set; }
    }
}

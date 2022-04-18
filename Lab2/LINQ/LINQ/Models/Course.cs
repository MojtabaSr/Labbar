using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LINQ.Models
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }

        public List<Teacher> Teachers { get; set; }


    }
}

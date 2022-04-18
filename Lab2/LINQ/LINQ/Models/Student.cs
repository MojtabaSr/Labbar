using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LINQ.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; }

        public ICollection<StudentTeacher> StudentTeacher { get; set; }

        public int ClassId { get; set; }

    }

}




using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LINQ.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }    
        [Required]
        public string TeacherName { get; set; }

        public ICollection<StudentTeacher> StudentTeacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ.Models
{
    public class StudentTeacher
    {
        public int StudentTeacherId { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}

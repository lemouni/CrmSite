using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Teacher_Course
    {
        public int id { get; set; }
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public int Teacherid { get; set; }
        public int Courseid { get; set; }
    }
}

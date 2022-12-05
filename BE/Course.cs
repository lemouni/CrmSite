using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Course
    {
        public int id { get; set; }
        public string Title { get; set; }
        public float TotalTime { get; set; }
        public string Descript { get; set; }
        public string VideoIntro { get; set; }
        public float Price { get; set; }
        public List<Teacher_Course> Teacher_Courses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Teacher
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string pic { get; set; }
        public List<Teacher_Course> Teacher_Courses { get; set; }
    }
}

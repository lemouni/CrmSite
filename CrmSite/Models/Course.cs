using BE;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CrmSite.Models
{
    public class Course
    {
        public int id { get; set; }
        public string Title { get; set; }
        public float TotalTime { get; set; }
        public string Descript { get; set; }
        public IFormFile VideoIntro { get; set; }
        public float Price { get; set; }

    }
}

using Microsoft.AspNetCore.Http;
using System;

namespace CrmSite.Models
{
    public class Teacher
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public IFormFile pic { get; set; }
    }
}

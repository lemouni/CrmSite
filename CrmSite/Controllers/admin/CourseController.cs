using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BE;
using Microsoft.AspNetCore.Hosting;

namespace CrmSite.Controllers.admin
{
    public class CourseController : Controller
    {

        private IWebHostEnvironment Environment;
        public CourseController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            TeacherBLL bll = new TeacherBLL();
            ViewBag.Teachers = bll.read();
            return View();
        }
        public IActionResult getskip(int c)
        {
            CoursBLL bll = new CoursBLL();
            return View("Show", bll.getskip(c));
        }
        [HttpPost]
        public IActionResult create(Models.Course course)
        {
            CoursBLL bll = new CoursBLL();
            BE.Course t = new BE.Course();
            t.Title = course.Title;
            t.Descript = course.Descript;
            t.Price = course.Price;

            UploadFile upf = new UploadFile(Environment);
            t.VideoIntro = upf.uploadVideo(course.VideoIntro);

            bll.create(t);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult update(CrmSite.Models.Course course)
        {
            CoursBLL bll = new CoursBLL();
            BE.Course t = new BE.Course();
            t.id = course.id;
            t.Title = course.Title;
            t.Descript = course.Descript; 
            t.Price = course.Price;
            UploadFile upf = new UploadFile(Environment);
            if (t.VideoIntro != null)
                t.VideoIntro = upf.uploadVideo(course.VideoIntro);

            bll.update(t);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult search(string s)
        {
            TeacherBLL bll = new TeacherBLL();
            List<BE.Teacher> ll = bll.search(s);
            return View("Show", ll);
        }
        [HttpPost]
        public IActionResult dele(int id)
        {
            TeacherBLL bll = new TeacherBLL();
            bll.delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}

using BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BE;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using DAL;

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
        public IActionResult getall()
        {
            CoursBLL bll = new CoursBLL();
            ViewBag.Course = bll.getall();

            return View();
        }
        public IActionResult edit(int id)
        {
            CoursBLL blc = new CoursBLL();
            var becourse = blc.search(id);

            TeacherBLL bll = new TeacherBLL();
            ViewBag.Teachers = bll.read();

            var modelcourse = new Models.Course
            {
                Title = becourse.Title,
                Price = becourse.Price,
                Descript = becourse.Descript,
                TotalTime = becourse.TotalTime,
                videoUrl = becourse.VideoIntro,
                id = becourse.id,
                teachers = becourse.Teacher_Courses.Select(s => s.Teacher.id).ToList()
            };

            return View(modelcourse);
        }
        public IActionResult getskip(int c)
        {
            CoursBLL bll = new CoursBLL();
            return View("Show", bll.getskip(c));
        }
        public IActionResult Edit1(Models.Course course)
        {
            CoursBLL blc = new CoursBLL();
            var becourse = blc.search(course.id);

            becourse.id = course.id;
            becourse.Title = course.Title;
            becourse.Price = course.Price;
            becourse.Descript = course.Descript;
            becourse.TotalTime = course.TotalTime;

            if (course.VideoIntro != null)
            {
                UploadFile uf = new UploadFile(Environment);
                becourse.VideoIntro = uf.uploadVideo(course.VideoIntro);
            }

            blc.update(becourse);


            DB db = new DB();
            List<Teacher_Course> tc = blc.listteachercourse(course.id);
            db.Teacher_Courses.RemoveRange(tc);
            db.SaveChanges();
            foreach (var item in course.teachers)
            {
                db.Teacher_Courses.Add(new Teacher_Course { Teacherid = item, Courseid = becourse.id });
                db.SaveChanges();
            }

            return RedirectToAction(nameof(getall));
        }

        [HttpPost]
        public IActionResult create(Models.Course course)
        {
            TeacherBLL bllt = new TeacherBLL();

            CoursBLL bll = new CoursBLL();
            BE.Course t = new BE.Course();
            t.Title = course.Title;
            t.Descript = course.Descript;
            t.Price = course.Price;
            t.TotalTime = course.TotalTime;
            
            UploadFile upf = new UploadFile(Environment);
            t.VideoIntro = upf.uploadVideo(course.VideoIntro);

            bll.create(t);

            DB db = new DB();
            foreach (var item in course.teachers)
            {
                db.Teacher_Courses.Add(new Teacher_Course { Teacherid = item, Courseid = t.id });
            db.SaveChanges();
            }
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
            CoursBLL bll = new CoursBLL();
            List<BE.Course> ll = bll.search(s);

            ViewBag.Course = ll;


            return View("getall");
        }
        [HttpPost]
        public IActionResult dele(int id)
        {
            CoursBLL bll = new CoursBLL();
            bll.delete(id);
            return RedirectToAction(nameof(getall));

        }
    }
}

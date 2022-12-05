using Microsoft.AspNetCore.Mvc;
//using BE;
using BLL;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Hosting;
using CrmSite;
using System.Collections.Generic;
using BE;

namespace Crm.Controllers.admin
{
    public class TeacherController : Controller
    {
        private IWebHostEnvironment Environment;
        public TeacherController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Show()
        {
            TeacherBLL bll = new TeacherBLL();
            return View(bll.getskip(0));

            //return View(bll.read());
        }
        public IActionResult getskip(int c)
        {
            TeacherBLL bll = new TeacherBLL();
            return View("Show",bll.getskip(c));
        }
        [HttpPost]
        public IActionResult create(CrmSite.Models.Teacher Teacher)
        {
            TeacherBLL bll = new TeacherBLL();
            BE.Teacher t = new BE.Teacher();
            t.Name = Teacher.Name;
            t.Family = Teacher.Family;
            t.Email = Teacher.Email;
            UploadFile upf = new UploadFile(Environment);
            t.pic = upf.Upload(Teacher.pic);
            bll.create(t);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult update(CrmSite.Models.Teacher Teacher)
        {
            TeacherBLL bll = new TeacherBLL();
            BE.Teacher t = new BE.Teacher();
            t.id = Teacher.id;
            t.Name = Teacher.Name;
            t.Family = Teacher.Family;
            t.Email = Teacher.Email;
            UploadFile upf = new UploadFile(Environment);
            t.pic = upf.Upload(Teacher.pic);
            bll.update(t);

            return RedirectToAction(nameof(Show));
        }
        [HttpGet]
        public IActionResult search(string s)
        {
            TeacherBLL bll = new TeacherBLL();
            List<BE.Teacher> ll = bll.search(s);
            return View("Show" , ll);
        }
        [HttpPost]
        public IActionResult dele(int id)
        {
            TeacherBLL bll = new TeacherBLL();
            bll.delete(id);
            return RedirectToAction(nameof(Show));

        }
    }
}

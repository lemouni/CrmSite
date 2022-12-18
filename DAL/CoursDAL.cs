using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class CoursDAL
    {
        public void create(Course c)
        {
            DB db = new DB();
            db.Courses.Add(c);
            db.SaveChanges();
        }
        public List<Course> getall()
        {
            DB db = new DB();
            var q = from i in db.Courses select i;
            return q.ToList();
        }
        public int gettotal()
        {
            DB db = new DB();
            return db.Courses.Count();
        }
        public List<Course> getskip(int c)
        {
            int t = c * 10;
            DB db = new DB();
            var q = db.Courses.Skip(t).Take(10);
            return q.ToList();
        }
        public void update(Course t)
        {
            DB db = new DB();
            var q = from i in db.Courses where i.id == t.id select i;
            Course tt = new Course();
            tt = q.Single();
            tt.Title = t.Title;
            tt.TotalTime = t.TotalTime;
            tt.VideoIntro = t.VideoIntro;
            tt.Price = t.Price;
            tt.Descript = t.Descript;
            db.SaveChanges();
        }
        public List<Course> search(string s)
        {

            //    DB db = new DB();
            //    var q = from i in db.Courses
            //            where i.Title.Contains(s)
            //            select i;


            //return q.ToList();

            int n = 0;

            DB db = new DB();
            var q = from i in db.Courses
                    where i.Title.Contains(s.ToString()) || (int.TryParse(s,out n) ? i.Price ==n : false)
                    select i;


            return q.ToList();
        }

        public Course search(int id)
        {
            DB db = new DB();
            var q = from i in db.Courses.Include(s=>s.Teacher_Courses).ThenInclude(s=>s.Teacher)
                    where i.id==id
                    select i;


            return q.SingleOrDefault();
        }
        public void delete(int id)
        {
            DB db = new DB();
            var q = from i in db.Courses where i.id == id select i;
            Course tt = new Course();
            tt = q.Single();

            db.Remove(tt);
            db.SaveChanges();
        }
        public List<Teacher_Course> listteachercourse(int id)
        {
            DB db = new DB();
            var q = db.Teacher_Courses.Where(s => s.Courseid == id).ToList();


            return q.ToList();
        }
    }
}

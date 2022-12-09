using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

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

                DB db = new DB();
                var q = from i in db.Courses
                        where i.Title.Contains(s)
                        select i;


            return q.ToList();
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BE;

namespace DAL
{
    public class TeacherDAL
    {
        public void create (Teacher t)
        {
            DB db = new DB();
            db.Teachers.Add(t);
            db.SaveChanges();   
        }
        public List<Teacher> read()
        {
            DB db = new DB();
            return db.Teachers.ToList();
        }
        public void update(Teacher t)
        {
            DB db = new DB();
            var q=from i in db.Teachers where i.id ==t.id select i;
            Teacher tt = new Teacher();
            tt = q.Single();
            tt.Name = t.Name;
            tt.Family = t.Family;
            tt.Email = t.Email;
            if (t.pic!="")
            tt.pic = t.pic;
            db.SaveChanges();
        }
        public List<Teacher> search(string s)
        {
            DB db = new DB();
            var q = from i in db.Teachers
                    where i.Name.Contains(s)
                    select i;
            return q.ToList();
        }

        public int gettotal()
        {
            DB db = new DB();
            return db.Teachers.Count();
        }

        public List<Teacher> getskip(int c)
        {
            int t = c * 10;
            DB db = new DB();
            var q = db.Teachers.Skip(t).Take(10);
            return q.ToList();
        }
        public void delete(int id)
        {
            DB db = new DB();
            var q = from i in db.Teachers where i.id == id select i;
            Teacher tt = new Teacher();
            tt = q.Single();

            db.Remove(tt);
            db.SaveChanges();
        }
    }
}

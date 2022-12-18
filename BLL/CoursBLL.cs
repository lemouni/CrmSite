using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;

namespace BLL
{
    public class CoursBLL
    {
        CoursDAL dal = new CoursDAL();
        public void create(Course c)
        {
             dal.create(c);
        }
        public List<Course> getall()
        {
            return dal.getall();
        }
        public int gettotal()
        {
            return dal.gettotal();
        }
        public List<Course> getskip(int c)
        {
            return dal.getskip(c);
        }
        public void update(Course t)
        {
             dal.update(t);
        }
        public List<Course> search(string s)
        {
            return dal.search(s);
        }
        public Course search(int id)
        {
            return dal.search(id);
        }
        public void delete(int id)
        {
             dal.delete(id);
        }
        public List<Teacher_Course> listteachercourse(int id)
        {
            return dal.listteachercourse(id);
        }

    }
}

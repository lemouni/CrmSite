using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using BE;
using DAL;
using System.Linq;

namespace BLL
{
    public class TeacherBLL
    {
        public void create(Teacher t)
        {
            TeacherDAL dal = new TeacherDAL();
            dal.create(t);
        }
        public List<Teacher> read()
        {
            TeacherDAL dal = new TeacherDAL();
            return dal.read();
        }
        public void update(Teacher t)
        {
            TeacherDAL dal = new TeacherDAL();
            dal.update(t);
        }
        public List<Teacher> search(string s)
        {
            TeacherDAL dal = new TeacherDAL();
            return dal.search(s);
        }
        public int gettotal()
        {
            TeacherDAL dal = new TeacherDAL();
            return dal.gettotal();
        }

        public List<Teacher> getskip(int c)
        {
            TeacherDAL dal = new TeacherDAL();
            return dal.getskip(c);
        }
        public void delete(int id)
        {
            TeacherDAL dal = new TeacherDAL();
            dal.delete(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace CrmSite.ViewComponents.user
{
    public class TeachersViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            BLL.TeacherBLL bll = new BLL.TeacherBLL();
            return View("_teachers",bll.read());
        }
    }
}

using System.Web.Mvc;

namespace KamikazeThinhPhat.Web.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Directorate()
        {
            return View();
        }

        public ActionResult Diagram()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult HeaderWrapperOrganize()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult MenuOrganize()
        {
            return PartialView();
        }
    }
}
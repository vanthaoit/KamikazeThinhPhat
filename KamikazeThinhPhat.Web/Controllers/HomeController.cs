using System.Web.Mvc;

namespace KamikazeThinhPhat.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Navigation()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Slider()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}
using System.Web.Mvc;

namespace KamikazeThinhPhat.Web.Controllers
{
    public class PortfolioController : Controller
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
        public ActionResult Banner()
        {
            return PartialView();
        }
        
    }
}
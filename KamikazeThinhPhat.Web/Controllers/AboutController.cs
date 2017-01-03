using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Service;
using KamikazeThinhPhat.Web.Models;
using System.Web.Mvc;

namespace KamikazeThinhPhat.Web.Controllers
{
    public class AboutController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public AboutController(IProductService productService,IProductCategoryService productCategoryService,ICommonService commonService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _commonService = commonService;

        }


        public ActionResult Index(string alias)
        {
            var dbAboutModel = _productService.GetByAlias(alias) ;
            var dbAboutViewModel = AutoMapper.Mapper.Map<Product, ProductViewModel>(dbAboutModel);
            return View(dbAboutViewModel);
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
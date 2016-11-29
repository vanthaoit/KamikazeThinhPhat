using KamikazeThinhPhat.Service;
using System.Web.Mvc;
using KamikazeThinhPhat.Model;
using KamikazeThinhPhat.Web.Models;
using KamikazeThinhPhat.Model.Models;
using System.Collections.Generic;

namespace KamikazeThinhPhat.Web.Controllers
{
    public class HomeController : Controller
    {
        ISlideService _slideService;
        IProductCategoryService _productCategoryService;
        ICommonService _commonService;
        public HomeController(ISlideService slideService,IProductCategoryService productCategoryService,ICommonService commonService)
        {
            _slideService = slideService;
            _productCategoryService = productCategoryService;
            _commonService = commonService;

        }

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
            var navigationMenuModel = _commonService.GetNavigationMenu();
            var navigationMenuchildModel = _commonService.GetNavigationMenuChild();
            ViewBag.NavigationMenu = AutoMapper.Mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategoryViewModel>>(navigationMenuModel);
            ViewBag.NavigationMenuChild = AutoMapper.Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(navigationMenuchildModel);

            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Slider()
        {
            var slideModelData = _slideService.GetAll();
            var slideViewModelData = AutoMapper.Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModelData);
            return PartialView(slideViewModelData);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
    }
}
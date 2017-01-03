using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Service;
using KamikazeThinhPhat.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace KamikazeThinhPhat.Web.Controllers
{
    public class PortfolioController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public PortfolioController(ICommonService commonService,IProductCategoryService productCategoryService,IProductService productService)
        {
            _commonService = commonService;
            _productCategoryService = productCategoryService;
            _productService = productService;
        }

        public ActionResult Index(int id)
        {
            var dbProductModel = _productService.GetAllByCategoryId(id);
            var listBreadcrumbModel = _commonService.GetBreadcrumb(id);
            ViewBag.listBreadcrumb = AutoMapper.Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(listBreadcrumbModel);
            var dbProductViewModel = AutoMapper.Mapper.Map<IEnumerable<Product>,IEnumerable<ProductViewModel>>(dbProductModel);

            return View(dbProductViewModel);
        }
        public ActionResult Detail(int id, string alias)
        {
            string tamp = "khao-sat-dia-chat ";
            var bo = tamp.Equals(alias);
            var dbProductModel = _productService.GetById(id);
            var listBreadcrumModel = _commonService.GetBreadcrumb(dbProductModel.CategoryID);

            var singleProductCategory = _productCategoryService.GetById(dbProductModel.CategoryID);
            if (singleProductCategory.ParentID != null)
            {
                var listProductCategory = _productCategoryService.GetAllByParentId(singleProductCategory.ParentID.Value);
                ViewBag.relatedProductCategory = AutoMapper.Mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategoryViewModel>>(listProductCategory);
            }
           
            
            
            ViewBag.listBreadcrumb = AutoMapper.Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(listBreadcrumModel);
            var dbProductViewModel = AutoMapper.Mapper.Map<Product, ProductViewModel>(dbProductModel);

            List<string> listMoreImages = new JavaScriptSerializer().Deserialize<List<string>>(dbProductViewModel.MoreImages);
            ViewBag.ListMoreImages = listMoreImages;

            return View(dbProductViewModel);
        }

        [ChildActionOnly]
        public ActionResult Banner()
        {
            return PartialView();
        }
        
    }
}
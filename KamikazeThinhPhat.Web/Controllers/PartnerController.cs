using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Service;
using KamikazeThinhPhat.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace KamikazeThinhPhat.Web.Controllers
{
    public class PartnerController : Controller
    {
        private IProductCategoryService _productCategoryService;
        private IProductService _productService;
        private ICommonService _commonService;

        public PartnerController(IProductCategoryService productCategoryService, IProductService productService, ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _commonService = commonService;
        }

        public ActionResult Index()
        {
            string alias = "doi-tac";
            var dbProductCategoryModel = _productCategoryService.GetByAlias(alias);
            var categoryId = dbProductCategoryModel.ID;
            var dbProductModel = _productService.GetAllByCategoryId(categoryId);

            var dbProductCategoryViewModel = AutoMapper.Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategoryModel);
            ViewBag.productCategory = dbProductCategoryViewModel;
            var dbProductViewModel = AutoMapper.Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(dbProductModel);
            return View(dbProductViewModel);
        }
        public ActionResult Detail(int id, string alias)
        {
            
            try
            {
                
                var dbProductModel = _productService.GetById(id);
                var dbProductCategoryModel = _commonService.GetBreadcrumb(dbProductModel.CategoryID);
                var dbProductCategoryViewModel = AutoMapper.Mapper.Map<IEnumerable<ProductCategory>,IEnumerable<ProductCategoryViewModel> >(dbProductCategoryModel);
                var dbProductViewModel = AutoMapper.Mapper.Map<Product, ProductViewModel>(dbProductModel);
                List<string> listMoreImages = new JavaScriptSerializer().Deserialize<List<string>>(dbProductViewModel.MoreImages);
                ViewBag.listMoreImages = listMoreImages;
                ViewBag.productCategory = dbProductCategoryViewModel;
                return View(dbProductViewModel);
            }
            catch (Exception e)
            {
                var error = e.ToString();
                return View();
            }
           

        }
    }
}
using AutoMapper;
using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Service;
using KamikazeThinhPhat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace KamikazeThinhPhat.Web.Controllers
{
    public class LedgerController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        private ICommonService _commonService;

        public LedgerController(IProductService productService, IProductCategoryService productCategoryService, ICommonService commonService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
            _commonService = commonService;
        }

        public ActionResult Default()
        {
            try
            {
                string alias = "ho-so-phap-ly";
                var dbProductCategoryModel = _productCategoryService.GetByAlias(alias);

                var dbProductModel = new Product();
                IEnumerable<Product> listProductIdModel = _productService.GetAllByCategoryId(dbProductCategoryModel.ID);

                int firstId = listProductIdModel.First().ID;
                dbProductModel = _productService.GetById(firstId);

                var dbProductViewModel = Mapper.Map<Product, ProductViewModel>(dbProductModel);
                var listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listProductIdModel);
                ViewBag.listProductViewModel = listProductViewModel;
                return View(dbProductViewModel);
            }
            catch (Exception e)
            {
                var ex = e.ToString();
                return View(ex);
            }
        }

        public ActionResult Index(int id)
        {
            try
            {
                string alias = "ho-so-phap-ly";
                var dbProductCategoryModel = _productCategoryService.GetByAlias(alias);

                var dbProductModel = new Product();
                IEnumerable<Product> listProductIdModel = _productService.GetAllByCategoryId(dbProductCategoryModel.ID);

                dbProductModel = _productService.GetById(id);

                var dbProductViewModel = Mapper.Map<Product, ProductViewModel>(dbProductModel);
                var listProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listProductIdModel);
                ViewBag.listProductViewModel = listProductViewModel;
                return View(dbProductViewModel);
            }
            catch (Exception e)
            {
                var ex = e.ToString();
                return View(ex);
            }
        }
    }
}
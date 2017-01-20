using AutoMapper;
using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Service;
using KamikazeThinhPhat.Web.Infrastructure.Core;
using KamikazeThinhPhat.Web.Infrastructure.Extensions;
using KamikazeThinhPhat.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KamikazeThinhPhat.Web.Api
{
    [RoutePrefix("api/productcategory")]
    [Authorize]
    public class ProductCategoryController : ApiControllerBase
    {
        #region Initialize
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService)
                : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

        #endregion Initialize

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                var totalRow = 0;
                var listCategory = _productCategoryService.GetAll(keyword);
                totalRow = listCategory.Count();//
                var queryListCategory = listCategory.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);//
                var listCategoryVm = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(queryListCategory);//
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Items = listCategoryVm
                };

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, paginationSet);

                return response;
            });
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _productCategoryService.GetAll();

                var listCategoryVm = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(listCategory);//

                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listCategoryVm);

                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request,()=> {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
                }
                else
                {
                    var dbProductCategory = _productCategoryService.GetById(id);
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created,responseData);
                }
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductCategoryViewModel productCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    ProductCategory newProductCategory = new ProductCategory();
                    newProductCategory.UpdateProductCategory(productCategoryVm);
                    newProductCategory.CreatedDate = DateTime.Now;
                    newProductCategory.CreatedBy = User.Identity.Name;
                    _productCategoryService.Add(newProductCategory);
                    _productCategoryService.Save();

                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request,()=> {
                HttpResponseMessage response = null;

                if(!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
                }
                else
                {
                    var deleteProductCategory = _productCategoryService.Delete(id);
                    _productCategoryService.Save();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(deleteProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created,responseData);
                }
                return response;
            });
        }
        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel productCategoryVm)
        {
            return CreateHttpResponse(request,()=> {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
                }
                else
                {
                    var newProductCategory = _productCategoryService.GetById(productCategoryVm.ID);
                    newProductCategory.UpdateProductCategory(productCategoryVm);
                    newProductCategory.UpdatedDate = DateTime.Now;
                    newProductCategory.UpdatedBy = User.Identity.Name;
                   
                    _productCategoryService.Update(newProductCategory);
                    _productCategoryService.Save();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(newProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created,responseData);
                }
                return response;

            });
        }
    }
}
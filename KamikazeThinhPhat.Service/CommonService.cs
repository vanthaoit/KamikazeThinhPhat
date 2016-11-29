using KamikazeThinhPhat.Common;
using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Data.Repositories;
using KamikazeThinhPhat.Model.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace KamikazeThinhPhat.Service
{
    public interface ICommonService
    {
        Footer GetFooter();

        IEnumerable<Slide> GetSlide();

        IEnumerable<ProductCategory> GetNavigationMenu();

        IEnumerable<ProductCategory> GetNavigationMenuChild();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private ISlideRepository _slideRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IFooterRepository footerRepository, ISlideRepository slideRepository,IProductCategoryRepository productCategoryRepository, IUnitOfWork unitOfWork)
        {
            _footerRepository = footerRepository;
            _slideRepository = slideRepository;
            _productCategoryRepository = productCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstant.DefaultFooter);
        }

        public IEnumerable<Slide> GetSlide()
        {
            return _slideRepository.GetMulti(x => x.Status);
        }

        public IEnumerable<ProductCategory> GetNavigationMenu()
        {
            return _productCategoryRepository.GetMulti(x=>x.Status && x.ParentID == null).OrderBy(x=>x.DisplayOrder);
        }

        public IEnumerable<ProductCategory> GetNavigationMenuChild()
        {
            return _productCategoryRepository.GetMulti(x => x.Status && x.ParentID != null).OrderBy(x=>x.DisplayOrder);
        }
    }
}
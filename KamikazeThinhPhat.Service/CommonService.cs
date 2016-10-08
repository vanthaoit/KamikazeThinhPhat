using KamikazeThinhPhat.Common;
using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Data.Repositories;
using KamikazeThinhPhat.Model.Models;
using System.Collections.Generic;

namespace KamikazeThinhPhat.Service
{
    public interface ICommonService
    {
        Footer GetFooter();

        IEnumerable<Slide> GetSlide();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private ISlideRepository _slideRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IFooterRepository footerRepository, ISlideRepository slideRepository, IUnitOfWork unitOfWork)
        {
            _footerRepository = footerRepository;
            _slideRepository = slideRepository;
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
    }
}
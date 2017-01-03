using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Data.Repositories;
using KamikazeThinhPhat.Model.Models;

namespace KamikazeThinhPhat.Service
{
    public interface IContactDetailService
    {
        ContactDetail GetDefaultContact();
    }

    public class ContactDetailService : IContactDetailService
    {
        private IContactDetailRepository _contactDetailRepository;
        private IUnitOfWork _unitOfWork;

        public ContactDetailService(IUnitOfWork unitOfWork, IContactDetailRepository contactDetailRepository)
        {
            _contactDetailRepository = contactDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public ContactDetail GetDefaultContact()
        {
            return _contactDetailRepository.GetSingleByCondition(x => x.Status);
        }
    }
}
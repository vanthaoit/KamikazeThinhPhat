using KamikazeThinhPhat.Data.Infrastructure;
using KamikazeThinhPhat.Data.Repositories;
using KamikazeThinhPhat.Model.Models;

namespace KamikazeThinhPhat.Service
{
    public interface IFeedbackService
    {
        Feedback Create(Feedback feedback);

        void Save();
    }

    public class FeedbackService : IFeedbackService
    {
        private IUnitOfWork _unitOfWork;
        private IFeedbackRepository _feedbackRepository;

        public FeedbackService(IUnitOfWork unitOfWork, IFeedbackRepository feedbackRepository)
        {
            _unitOfWork = unitOfWork;
            _feedbackRepository = feedbackRepository;
        }

        public Feedback Create(Feedback feedback)
        {
            return _feedbackRepository.Add(feedback);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
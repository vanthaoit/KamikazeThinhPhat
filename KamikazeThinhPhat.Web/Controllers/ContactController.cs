using BotDetect.Web.Mvc;
using KamikazeThinhPhat.Common;
using KamikazeThinhPhat.Model.Models;
using KamikazeThinhPhat.Service;
using KamikazeThinhPhat.Web.Infrastructure.Extensions;
using KamikazeThinhPhat.Web.Models;
using System.Web.Mvc;


namespace KamikazeThinhPhat.Web.Controllers
{
    public class ContactController : Controller
    {
        private IContactDetailService _contactDetailService;
        private IFeedbackService _feedbackService; 
        public ContactController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            _contactDetailService = contactDetailService;
            _feedbackService = feedbackService;
        }

        private ContactDetailViewModel GetDetail()
        {
            var model = _contactDetailService.GetDefaultContact();
            var viewModelData = AutoMapper.Mapper.Map<ContactDetail, ContactDetailViewModel>(model);
            return viewModelData;
        }
        public ActionResult Index()
        {
            FeedbackViewModel feedbackViewModelData = new FeedbackViewModel();
            feedbackViewModelData.ContactDetail = GetDetail();
            return View(feedbackViewModelData);
        }
        [HttpPost]
        [CaptchaValidation("CaptchaCode", "contactCaptcha","Mã xác nhận không đúng !!!")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            
            if (ModelState.IsValid)
            {
                Feedback newFeedback = new Feedback();
                newFeedback.UpdateFeedback(feedbackViewModel);
                _feedbackService.Create(newFeedback);
                _feedbackService.Save();

                ViewData["SuccessMsg"] = "Gửi phản hồi thành công";
                string content = System.IO.File.ReadAllText(Server.MapPath("/Assets/client/template/contact_template.html"));
                content = content.Replace("{{Name}}",feedbackViewModel.Name);
                content = content.Replace("{{Email}}",feedbackViewModel.Email);
                content = content.Replace("{{Message}}",feedbackViewModel.Message);
                var adminEmail = ConfigHelper.GetByKey("AdminEmail");
                MailHelper.SendMail(adminEmail,"Nội dung phản hồi",content);
                feedbackViewModel.Name = "";
                feedbackViewModel.Email = "";
                feedbackViewModel.Message = "";
            }
            feedbackViewModel.ContactDetail = GetDetail();
            return View("Index",feedbackViewModel);
        }
    }
}
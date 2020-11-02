using System;
using PhoneBook.Data.Infrastructure;
using PhoneBook.Domain.Model;
using PhoneBook.ServicePlatform.ExternalContracts;

namespace PhoneBook.BusinessLibrary.Services
{
    public class CaptchaService : ICaptchaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CaptchaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateQuestion(Captcha captcha)
        {
            _unitOfWork.CaptchaRepository.Insert(captcha);
            _unitOfWork.Commit();
        }
        public Captcha GenerateCaptcha()
        {
            Random randomCaptchaId = new Random();
            int captchaId = randomCaptchaId.Next(_unitOfWork.CaptchaRepository.MinCaptchaId(), _unitOfWork.CaptchaRepository.MaxCaptchaId() + 1);
            return _unitOfWork.CaptchaRepository.Single(captchaId);
        }
    }
}

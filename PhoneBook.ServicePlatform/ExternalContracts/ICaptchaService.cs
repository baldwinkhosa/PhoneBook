using PhoneBook.Domain.Model;

namespace PhoneBook.ServicePlatform.ExternalContracts
{
    public interface ICaptchaService
    {
        void CreateQuestion(Captcha captcha);
        Captcha GenerateCaptcha();
    }
}

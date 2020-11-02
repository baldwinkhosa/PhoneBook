using System.Data.Entity.ModelConfiguration;
using PhoneBook.Domain.Model;

namespace PhoneBook.Data.Configuration
{
    public class CaptchaConfig : EntityTypeConfiguration<Captcha>
    {
        public CaptchaConfig()
        {
            HasKey(m => m.CaptchaId);
        }

    }
}

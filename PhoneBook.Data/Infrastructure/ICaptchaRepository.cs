using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Domain.Model;

namespace PhoneBook.Data.Infrastructure
{
    public interface ICaptchaRepository : IRepository<Captcha>
    {
        int MinCaptchaId();
        int MaxCaptchaId();
    }
}

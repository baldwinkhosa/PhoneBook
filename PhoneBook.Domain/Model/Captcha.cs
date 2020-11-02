using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Model
{
    public class Captcha
    {
        public Captcha()
        {
            CreatedDate = DateTime.Now;
        }
        public int CaptchaId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; private set; }
    }
}

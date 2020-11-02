using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBook.WebPlatform.ViewModels
{
    public class ContactDetailViewModel
    {
        public int ContactId { get; set; }
        public string ContactDetailType { get; set; }
        public string ContactDetailValue { get; set; }
    }
}
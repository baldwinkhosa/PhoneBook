using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Domain.Model
{
    public class User
    {
        public User()
        {
            CreatedDate = DateTime.Now;
            Contacts = new List<Contact>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PhoneBook.WebPlatform.ViewModels
{
    public class ContactViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
    }
}
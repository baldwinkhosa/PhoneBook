using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.WebPlatform.ViewModels
{
    public class UserViewModel
    {

        [Required(ErrorMessage = "Username is required.")]
        [MinLength(5, ErrorMessage = "Pick username with minimun 5 characters.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = ("Your password is less than 8 characters."))]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Invalid password combination.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required.")]
        [Compare("Password", ErrorMessage = "Confirm password and Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Enter valid email e.g. someone@someone.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Captcha answer cannot be null")]
        public string CaptchaAnswer { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
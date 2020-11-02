using System.Web.Mvc;
using AutoMapper;
using PhoneBook.Domain.Model;
using PhoneBook.ServicePlatform.ExternalContracts;
using PhoneBook.WebPlatform.Helpers;
using PhoneBook.WebPlatform.ViewModels;

namespace PhoneBook.WebPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        private readonly IContactService _contactService;

        public HomeController(IContactService contactService, IUserService UserService)
        {
            _userService = UserService;
            _contactService = contactService;
        }

        public ViewResult DashBoard()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return PartialView();
        }

        public ActionResult NewPopup()
        {
            return PartialView();
        }
        [HttpGet]
        public ActionResult CreateNewContact()
        {
            return PartialView("Contact");
        }
        [HttpPost]
        public ActionResult CreateNewContact(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Contact");

            }
            return Json(new { success = false });
            model.UserId = PhoneBookSessionManager.LoggedInUserId;
            Mapper.CreateMap<ContactViewModel, Contact>();
            Contact contact = Mapper.Map<Contact>(model);
            int contactId = _contactService.CreateContact(contact);
            if (contactId > 0)
            {
                TempData["SuccessMessage"] = "New Contact Created";
            }
            return View("Dashboard");
        }
    }
}
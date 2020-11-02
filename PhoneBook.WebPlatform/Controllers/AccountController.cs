using System.Web.Mvc;
using AutoMapper;
using PhoneBook.Domain.Model;
using PhoneBook.ServicePlatform.ExternalContracts;
using PhoneBook.WebPlatform.Helpers;
using PhoneBook.WebPlatform.ViewModels;

namespace PhoneBook.WebPlatform.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICaptchaService _captchaService;

        public AccountController(IUserService userService, ICaptchaService captchaService)
        {
            _userService = userService;
            _captchaService = captchaService;
        }

        #region CreateAccount
        [HttpGet]
        public ActionResult CreateUser()
        {
            Captcha captcha = _captchaService.GenerateCaptcha();
            Session["CaptchaQuestion"] = captcha.Question;
            Session["CaptchaAnswer"] = captcha.Answer;
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            string captchaAnswer = Session["CaptchaAnswer"] as string;
            if (model.CaptchaAnswer.Equals(captchaAnswer))
            {
                Mapper.CreateMap<UserViewModel, User>();
                User user = Mapper.Map<User>(model);
                int userId = _userService.CreateUser(user);
                if (userId > 0)
                {
                    TempData["UserCreated"] = string.Concat(model.FirstName, ", your account has been created.");
                    TempData["UserName"] = model.UserName;
                    return RedirectToAction("CreateUser");
                }
                TempData["UserCreated"] = string.Concat("User name ", model.UserName, " is not available.Please try other username.");
                return View();
            }
            ModelState.AddModelError("invalidCaptcha", "Invalid answer.");
            return View(model);
        }
        #endregion

        #region ForgotPassword
        public ActionResult ForgotPassword()
        {
            return View("ForgotPassword");
        }
        #endregion

        #region UserLogin
        [HttpGet]
        public ActionResult UserLogin(string user)
        {
            ViewBag.UserName = user;

            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(ApplicationUserViewModel model)
        {
            if (!ModelState.IsValid) return View();
            Mapper.CreateMap<ApplicationUserViewModel, User>();
            User user = Mapper.Map<User>(model);
            user = _userService.Exists(user);
            if (user != null)
            {
                PhoneBookSessionManager.LoggedInUserName = user.UserName;
                PhoneBookSessionManager.LoggedInUserId = user.UserId;
                return RedirectToAction("DashBoard", "Home");
            }
            ModelState.AddModelError("InvalidLogin", "Invalid username/password combination.");
            return View();
        }
        #endregion
    }
}

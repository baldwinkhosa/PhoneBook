using System;
using System.Web;

namespace PhoneBook.WebPlatform.Helpers
{
    public class PhoneBookSessionManager
    {
        private const string LoggedInUserNameSession = "LoggedInUserName";
        private const string LoggedInUserIdSession = "LoggedInUserId";

        public static int LoggedInUserId
        {
            get
            {
                return Convert.ToInt32(HttpContext.Current.Session[LoggedInUserIdSession]);
            }
            set
            {
                HttpContext.Current.Session[LoggedInUserIdSession] = value;
            }
        }
        public static string LoggedInUserName
        {
            get
            {
                return HttpContext.Current.Session[LoggedInUserNameSession] as string;
            }
            set
            {
                HttpContext.Current.Session[LoggedInUserNameSession] = value;
            }
        }

    }
}

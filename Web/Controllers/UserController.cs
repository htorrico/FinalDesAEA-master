using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {

            FormsAuthentication.SetAuthCookie("htorrico", false);

            var authTicket = new FormsAuthenticationTicket(1, "htorrico", DateTime.Now, DateTime.Now.AddMinutes(20), false, "Admin");
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Response.Cookies.Add(authCookie);

            return View();
        }

        public ActionResult LogOff()
        {
            //AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}
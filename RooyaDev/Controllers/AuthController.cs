using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RooyaDev.Models;

namespace RooyaDev.Controllers
{
    [HandleError(View = "~/Views/Shared/Error.cshtml")]
    public class AuthController : Controller
    {
        DB db = new DB();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string User_Name,string Password,string ReturnURL=null)
        {
            if(db.Admins.Any(x=>x.User_Name==User_Name&&x.Password==Password))
            {
                Admin admin = db.Admins.Single(x => x.User_Name == User_Name && x.Password == Password);
                FormsAuthentication.SetAuthCookie(admin.ID.ToString(), false);
                if (Url.IsLocalUrl(ReturnURL) && ReturnURL != null)
                {
                    return Redirect(ReturnURL);
                }
                else
                {
                    return RedirectToAction("Index", "Admins");
                }

            }
            ViewBag.error = "Invalid User Name And Password !";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
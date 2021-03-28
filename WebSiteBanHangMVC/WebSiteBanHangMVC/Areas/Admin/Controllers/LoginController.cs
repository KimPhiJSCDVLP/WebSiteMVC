using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSiteBanHangMVC.Areas.Admin.Models;
using WebSiteBanHangMVC.Models;
using WebSiteBanHangMVC.Utils;

namespace WebSiteBanHangMVC.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var sessionLogin = Session["LoginModel"] as UserLogin;
            if (!ModelState.IsValid)
            {
                return View("_Error");
            }
            else
            {
                if (loginModel != null)
                {
                    using (var db = new ApplicationDbContext())
                    {
                        var user = db.Users.FirstOrDefault(x => x.UserName.Equals(loginModel.UserName));
                        if (user != null)
                        {
                            var passwordHash = Encryptor.MD5Hash(loginModel.Password);
                            if (passwordHash.Equals(user.PasswordSalt))
                            {
                                var userLogin = new UserLogin();
                                userLogin.UserId = user.UserID;
                                userLogin.UserName = user.UserName;
                                if (sessionLogin == null)
                                {
                                    sessionLogin = new UserLogin();
                                }
                                sessionLogin = userLogin;
                                return RedirectToAction("Index", "Admin");
                            }
                        }
                        else
                        {
                            return View("Index");
                        }
                    }
                }
            }
            return View("Index");
        }

        public ActionResult Logout(LoginModel loginModel)
        {
            Session["LoginModel"] = null;
            return RedirectToAction("Index");
        }
    }
}
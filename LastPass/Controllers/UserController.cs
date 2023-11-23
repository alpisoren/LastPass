using LastPass.Models.DataContext;
using LastPass.Models.Model;
using LastPass.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastPass.Controllers
{
    public class UserController : BaseController
    {
        private UserRepository userRepository;
        public UserController()
        {
             userRepository = new UserRepository(new dbContext());
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var login = userRepository.GetByUserName(user.UserName);
            if (login!=null)
            {
                if (login.UserName == user.UserName && login.Password == user.Password)
                {
                    Session["id"] = login.Id;
                    Session["UserName"] = login.UserName;
                    HttpContext.Session.Add("id", login.Id);

                    return RedirectToAction("Index", "PasswordRecord");
                }

                ViewBag.Uyari = "Kullanıcı adı ya da şifre yanlış";
            }
            else
            {
                ViewBag.Uyari = "Kayıtlı kullanıcı bulunamadı";
            }
            return Login();
        }

        public ActionResult Logout()
        {
            Session["id"] = null;
            Session["UserName"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }



        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User User)
        {
            if (ModelState.IsValid)
            {
                if (!userRepository.UserNameExist(User.UserName))
                {

                    userRepository.Create(User);
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("Username", "Kullanıcı adı mevcut");
                    return View(User);
                }

            }
            return View();
        }
       

    }
}

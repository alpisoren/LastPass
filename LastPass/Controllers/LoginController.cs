using LastPass.Models.DataContext;
using LastPass.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastPass.Controllers
{
    public class LoginController : Controller
    {
        dbContext db = new dbContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var login = db.User.Where(x => x.UserName == user.UserName).SingleOrDefault();
            if (login.UserName == user.UserName && login.Password == user.Password )//Crypto.Hash(user.Sifre, "MD5"))
            {
                Session["id"] = login.Id;
                Session["UserName"] = login.UserName;
                //Session["yetki"] = login.Yetki;

                return RedirectToAction("Index", "Login");
            }
            ViewBag.Uyari = "Kullanıcı adı ya da şifre yanlış";
            return View(login);
        }

        public ActionResult Logout()
        {
            Session["id"] = null;
            Session["UserName"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
        }



        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User User, string password, string userName)
        {

            if (ModelState.IsValid)
            {
                //User.Password = Crypto.Hash(password, "MD5");
                db.User.Add(User);
                db.SaveChanges();
                return RedirectToAction("Userler");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var user = db.User.Where(x => x.Id == id).SingleOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, User User, string password, string email)
        {

            if (ModelState.IsValid)
            {
                var user = db.User.Where(x => x.Id == id).SingleOrDefault();
                user.Password = password;// Crypto.Hash(password, "MD5");
                user.Email = User.Email;
                //user.Yetki = User.Yetki;


                db.User.Add(User);
                db.SaveChanges();
                return RedirectToAction("Userler");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var a = db.User.Where(x => x.Id == id).SingleOrDefault();
            if (a != null)
            {
                db.User.Remove(a);
                db.SaveChanges();
                return RedirectToAction("Userler");
            }
            return View();
        }

    }
}

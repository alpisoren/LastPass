using LastPass.Models.DataContext;
using LastPass.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastPass.Controllers
{
    public class BaseController : Controller
    {
        public User _user;
         
        dbContext db = new dbContext();

        public BaseController()
        {
            _user = GetActiveUser();
        }
        // GET: Base
        public User GetActiveUser()
        {
            if (Session != null)
            {
                var userId = Convert.ToInt32(Session["Id"]);
                var user = db.User.Where(x => x.Id == userId).SingleOrDefault();
                return user;
            }
            else
            {
                return null;
            }
           

        }
    }
}
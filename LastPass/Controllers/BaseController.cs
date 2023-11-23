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
        
        dbContext db = new dbContext();

        protected int CurrentUserId
        {
            get { return (int)Session["id"]; }
        }

        // GET: Base
        public User GetActiveUser()
        {
            if (Session != null)
            {
                var userId = CurrentUserId;
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
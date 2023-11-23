using LastPass.Models.DataContext;
using LastPass.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastPass.Repository
{
    public class UserRepository :BaseRepository<User>
    {
        private dbContext db = new dbContext();
        public UserRepository(dbContext context) : base(context)
        {
        }

        public User GetByUserName(string userName)
        {
            return db.User.Where(x => x.UserName == userName).SingleOrDefault();
        }
        public bool UserNameExist(string userName)
        {
            var result = false;
            var data = db.User.Where(x => x.UserName == userName).SingleOrDefault();
            if (data!=null)
            {
                result = true;
            }
            return result;
        }
    }

}
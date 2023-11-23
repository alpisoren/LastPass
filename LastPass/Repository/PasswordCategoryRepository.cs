using LastPass.Models.DataContext;
using LastPass.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LastPass.Repository
{
    public class PasswordCategoryRepository :BaseRepository<PasswordCategory>
    {
        private dbContext db = new dbContext();
        public PasswordCategoryRepository(dbContext context) : base(context)
        {

        }
    }
}
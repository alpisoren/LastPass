using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LastPass.Models.Model;
using System.Data;
using System.Data.Entity;

namespace LastPass.Models.DataContext
{
    public class dbContext :DbContext
    {
        public dbContext() : base("LastPassDB")
        {


        }
        public DbSet<User> User { get; set; }
        public DbSet<PasswordRecord> PasswordCaPasswordRecordtegory { get; set; }
        public DbSet<PasswordCategory> PasswordCategory { get; set; }



    }
}
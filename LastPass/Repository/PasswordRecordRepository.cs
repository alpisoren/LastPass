using LastPass.Models.DataContext;
using LastPass.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LastPass.Repository
{
    public class PasswordRecordRepository : BaseRepository<PasswordRecord>
    {
        private dbContext db = new dbContext();
        public PasswordRecordRepository(dbContext context) : base(context)
        {

        }

        public List<PasswordRecord> GetByActiveUser(int userID)
        {
            var source = db.PasswordRecord.Include("PasswordCategory").Where(x => x.User.Id == userID).ToList().OrderByDescending(y => y.Id).ToList();
            return source;
        }

        public override void Create(PasswordRecord entity)
        {
            db.Entry(entity.User).State = EntityState.Unchanged;
            db.Entry(entity.PasswordCategory).State = EntityState.Unchanged;
            db.PasswordRecord.Add(entity);
            db.SaveChanges();

        }
        public override void Update(PasswordRecord entity)
        {
            db.Entry(entity.User).State = EntityState.Unchanged;
            db.Entry(entity.PasswordCategory).State = EntityState.Unchanged;
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();

        }


        public List<PasswordCategory> GetPasswordCategories()
        {
            return db.Set<PasswordCategory>().ToList();

        }

    }
}
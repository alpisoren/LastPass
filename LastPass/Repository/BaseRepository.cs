using LastPass.Models.DataContext;
using LastPass.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LastPass.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private dbContext db;

        public BaseRepository(dbContext context)
        {
            this.db = context;
        }
        
        public virtual T GetById(int id)
        {
            return db.Set<T>().Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }


        public virtual void Create(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }


        public virtual void Delete(T entity)
        {
            //db.Set<T>().Remove(entity);
            db.Entry(entity).State= EntityState.Deleted;
            db.SaveChanges();
            //db.SaveChanges();
        }

    }
}
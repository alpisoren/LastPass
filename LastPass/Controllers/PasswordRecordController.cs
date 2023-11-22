using LastPass.Models.DataContext;
using LastPass.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastPass.Controllers
{
    public class PasswordRecordController : BaseController
    {

        dbContext db = new dbContext();
        // GET: PasswordRecord
        public ActionResult Index()
        {
            return View(db.PasswordRecord.Include("PasswordCategory").ToList().OrderByDescending(x => x.Id));
        }

        public ActionResult Create()
        {
            ViewBag.PasswordCategoryID = new SelectList(db.PasswordCategory, "PasswordCategoryID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PasswordRecord passwordRecord)
        {
            if (ModelState.IsValid)
            {

                passwordRecord.User = _user;

                //db.Entry(passwordRecord.User).State = EntityState.Unchanged;
                db.PasswordRecord.Add(passwordRecord);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(passwordRecord);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var passwordRecord = db.PasswordRecord.Where(x => x.Id == id).SingleOrDefault();
            if (passwordRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.PasswordCategoryID = new SelectList(db.PasswordCategory, "Id", "Name", passwordRecord.PasswordCategory.Id);
            return View(passwordRecord);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, PasswordRecord dto)
        {


            if (ModelState.IsValid)
            {
                var entity = db.PasswordRecord.Where(x => x.Id == id).SingleOrDefault();

                entity.Info = dto.Info;
                entity.Password = dto.Password;
                entity.URL = dto.URL;
                entity.UserName = dto.UserName;
                entity.PasswordCategory = dto.PasswordCategory;
                if (entity.User==null)
                {
                    entity.User = _user;
                }
                db.Entry(entity.User).State = EntityState.Unchanged;
                db.Entry(entity.PasswordCategory).State = EntityState.Unchanged;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dto);

        }

        public ActionResult Delete(int id)
        {

            var passwordRecord = db.PasswordRecord.Find(id);
            if (passwordRecord == null)
            {
                return HttpNotFound();
            }

            return View(passwordRecord);
        }

        // POST: Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            PasswordRecord passwordRecord = db.PasswordRecord.Find(id);
            if (passwordRecord == null)
            {
                return HttpNotFound();
            }
            

            db.PasswordRecord.Remove(passwordRecord);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
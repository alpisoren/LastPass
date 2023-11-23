using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LastPass.Models.DataContext;
using LastPass.Models.Model;

namespace LastPass.Controllers
{
    public class PasswordCategoriesController : Controller
    {
        private dbContext db = new dbContext();

        // GET: PasswordCategories
        public ActionResult Index()
        {
            return View(db.PasswordCategory.ToList());
        }

        // GET: PasswordCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PasswordCategory passwordCategory = db.PasswordCategory.Find(id);
            if (passwordCategory == null)
            {
                return HttpNotFound();
            }
            return View(passwordCategory);
        }

        // GET: PasswordCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PasswordCategories/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PasswordCategory passwordCategory)
        {
            if (ModelState.IsValid)
            {
                db.PasswordCategory.Add(passwordCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(passwordCategory);
        }

        // GET: PasswordCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PasswordCategory passwordCategory = db.PasswordCategory.Find(id);
            if (passwordCategory == null)
            {
                return HttpNotFound();
            }
            return View(passwordCategory);
        }

        // POST: PasswordCategories/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PasswordCategory passwordCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passwordCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(passwordCategory);
        }

        // GET: PasswordCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PasswordCategory passwordCategory = db.PasswordCategory.Find(id);
            if (passwordCategory == null)
            {
                return HttpNotFound();
            }
            return View(passwordCategory);
        }

        // POST: PasswordCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PasswordCategory passwordCategory = db.PasswordCategory.Find(id);
            db.PasswordCategory.Remove(passwordCategory);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

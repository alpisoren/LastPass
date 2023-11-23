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
using LastPass.Repository;

namespace LastPass.Controllers
{
    public class PasswordCategoriesController : Controller
    {
      
        private PasswordCategoryRepository passwordCategoriesRepository;
        public PasswordCategoriesController()
        {
            passwordCategoriesRepository = new PasswordCategoryRepository(new dbContext());
        }

        public ActionResult Index()
        {
            return View(passwordCategoriesRepository.GetAll().ToList());
        }


        // GET: PasswordCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] PasswordCategory passwordCategory)
        {
            if (ModelState.IsValid)
            {
                passwordCategoriesRepository.Create(passwordCategory);
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
            PasswordCategory passwordCategory = passwordCategoriesRepository.GetById((int)id);
            if (passwordCategory == null)
            {
                return HttpNotFound();
            }
            return View(passwordCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] PasswordCategory passwordCategory)
        {
            if (ModelState.IsValid)
            {
                passwordCategoriesRepository.Update(passwordCategory);
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
            PasswordCategory passwordCategory = passwordCategoriesRepository.GetById((int)id);
            if (passwordCategory == null)
            {
                return HttpNotFound();
            }
            return View(passwordCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PasswordCategory passwordCategory = passwordCategoriesRepository.GetById((int)id);
            passwordCategoriesRepository.Delete(passwordCategory);
            return RedirectToAction("Index");
        }

    }
}

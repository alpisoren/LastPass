using LastPass.Models.DataContext;
using LastPass.Models.Model;
using LastPass.Repository;
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
        private PasswordRecordRepository passwordRecordRepository;
        public PasswordRecordController()
        {
            passwordRecordRepository = new PasswordRecordRepository(new dbContext());
        }

        public ActionResult Index()
        {
            
            return View(passwordRecordRepository.GetByActiveUser(CurrentUserId));

        }

        public ActionResult Create()
        {

            ViewBag.PasswordCategory = new SelectList(passwordRecordRepository.GetPasswordCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PasswordRecord passwordRecord)
        {
            if (ModelState.IsValid) { 
                passwordRecord.User = GetActiveUser();
                passwordRecordRepository.Create(passwordRecord);
                return RedirectToAction("Index");

            }

            return View(passwordRecord);
        }
        
        [HttpPost]
        public string PasswordGenerator()
        {
            var newPass = "";
            newPass = Guid.NewGuid().ToString();
            return newPass;
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var passwordRecord = passwordRecordRepository.GetById((int)id);
            if (passwordRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.PasswordCategory = new SelectList(passwordRecordRepository.GetPasswordCategories(), "Id", "Name", passwordRecord.PasswordCategory?.Id);
            return View(passwordRecord);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int? id, PasswordRecord dto)
        {


            if (ModelState.IsValid)
            {
                var entity = passwordRecordRepository.GetById((int)id);

                if (entity.User == null)
                {
                    entity.User = GetActiveUser(); ;
                }
                entity.Info = dto.Info;
                entity.Password = dto.Password;
                entity.URL = dto.URL;
                entity.UserName = dto.UserName;
                entity.PasswordCategory = passwordRecordRepository.GetPasswordCategoriesById(dto.PasswordCategory.Id);

                passwordRecordRepository.Update(entity);
                return RedirectToAction("Index");
            }

            return View(dto);

        }

        public ActionResult Delete(int id)
        {

            var passwordRecord = passwordRecordRepository.GetById(id);
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
            PasswordRecord passwordRecord = passwordRecordRepository.GetById((int)id);
            if (passwordRecord == null)
            {
                return HttpNotFound();
            }
            passwordRecordRepository.Delete(passwordRecord);
            return RedirectToAction("Index");
        }

    }
}
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    public class ContactController : Controller
    {
        DbModel db = new DbModel();
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ContactSave(Contact contact)
        {

            db.contacts.Add(contact);
            db.SaveChanges();
            return Json(new { });

        }

        public JsonResult Contactshow()
        {
            var lstshow = db.contacts.ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);

        }

        public JsonResult delete(int id)
        {
            Contact lst = db.contacts.Find(id);
            db.contacts.Remove(lst);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Getbyid(int id)
        {
            Contact lst = db.contacts.Find(id);
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Contact contact)
        {
            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges() > 0)
            {
                return Json(new { success = true, result = contact });
            }
            else
            {
                return Json(new { success = false });
            }
        }

    }
}
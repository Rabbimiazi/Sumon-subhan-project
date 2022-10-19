using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {

        string strUserEmail = "";

        public void LoadSession()
        {
           
            strUserEmail = Session["strUserEmail"].ToString().Trim();

        }

        public void EmptySession()
        {

            Session["strUserEmail"] = "";

            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }



        DbModel db = new DbModel();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Reserveshow()
        {
            var lstshow = db.reserves.Where(r => r.Confirmed == false).ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);


        }
        public JsonResult ConfirmReserveshow()
        {
            var confirm= db.reserves.Where(r => r.Confirmed == true).ToList();
            return Json(confirm, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Contactshow()
        {
            var lstshow = db.contacts.ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);

        }

        public JsonResult MenueSave(Menue menue)
        {
            if (menue.FileImage != null)
            {
                string ext = Path.GetExtension(menue.FileImage.FileName).ToString();
                if (ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png" ||
                    ext.ToLower() == ".gif" || ext.ToLower() == ".pdf")
                {
                    string fileName = Path.GetFileNameWithoutExtension(menue.FileImage.FileName) + Guid.NewGuid() +
                                      ext;
                    menue.ImsgeUrl = "/AppFiles/Profile/" + fileName;
                    menue.FileImage.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Profile"), fileName));
                }

            }
            if (menue.MenueId > 0) {

                db.Entry(menue).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.menues.Add(menue);
            }

            if (db.SaveChanges() > 0)
            {
                return Json(new { success = true, result = menue });
            }
            else
            {
                return Json(new { success = false });
            }
            //db.SaveChanges();
            //return Json(new { });

        }


    

        public JsonResult MenueShow()
        {
            var lstshow = db.menues.ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);

        }

        public JsonResult deletemenue(int id)
        {
            Menue lst = db.menues.Find(id);
            db.menues.Remove(lst);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditMenueShow(int? id)
        {
            var lstshow = db.menues.Where(r => r.MenueId == id).SingleOrDefault();
            return Json(lstshow, JsonRequestBehavior.AllowGet);


        }

        public JsonResult OrderShow()
        {
            //LoadSession();
            //var eml = strUserEmail;

            //var lstshow = db.orders.ToList();
            var data = new List<ViewModel>();

             data = (from o in db.orders
                     join m in db.menues on o.DishId equals m.MenueId 
                     select new ViewModel
                     {
                         OrderId=o.OrderId,
                         Name=o.Name,
                         Email=o.Email,
                         Phone=o.Phone,
                         Date=o.Date,
                         OrderQuantity=o.OrderQuantity,
                         TotalPrice=o.TotalPrice,
                         DishTitle=m.DishTitle
                     }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);

        }

        public JsonResult ConfirmOrder(int id)
        {
            var data = db.orders.Where(em => em.OrderId == id).FirstOrDefault();

            data.Confirmed = true;

            db.Entry(data).State = System.Data.Entity.EntityState.Modified;


            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(data.Email);
            mail.From = new MailAddress("ruposhibanglacox@gmail.com", "Ruposhi Bangla Coxbazar", System.Text.Encoding.UTF8);

            mail.Subject = "Food Order";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Your Order Confirmed";

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("ruposhibanglacox@gmail.com", "ruposhi123");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);

                //mil.ProfileName = strUserName;
                //mil.CategoryType = strRegCategory;
                //db.mails.Add(mil);

            }
            catch (Exception ex)
            {
                Response.Write(ex);

            }

            if (db.SaveChanges() > 0)
            {
                return Json(new { success = true, result = data });
            }
            else
            {
                return Json(new { success = false });
            }
        }

      

        [AllowAnonymous]
        public JsonResult BreakfastShow()
        {
            var lstshow = db.menues.Where(r => r.MenueName == "Breakfast").ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);


        }

        [AllowAnonymous]
        public JsonResult LunchShow()
        {
            var lstshow = db.menues.Where(r => r.MenueName == "Lunch").ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);


        }

        [AllowAnonymous]
        public JsonResult DinnerShow()
        {
            var lstshow = db.menues.Where(r => r.MenueName == "Dinner").ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);


        }

        [AllowAnonymous]
        public JsonResult DrinksShow()
        {
            var lstshow = db.menues.Where(r => r.MenueName == "Drinks").ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);


        }

        [AllowAnonymous]
        public JsonResult DesertsShow()
        {
            var lstshow = db.menues.Where(r => r.MenueName == "Desert").ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);


        }

        [AllowAnonymous]
        public JsonResult DetailsShow()
        {
            var data = (from m in db.menues
                   where m.MenueName== "Detailsmenu"
                        select new ViewModel
                    {
                        MenueId = m.MenueId,
                        ImsgeUrl=m.ImsgeUrl
                      
                    }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);


        }

    }
}
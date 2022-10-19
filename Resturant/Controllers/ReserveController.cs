using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    public class ReserveController : Controller
    {

        string strUserId = "";
        string strUserName = "";
        string strContactNumber = "";
        string strUserEmail = "";
       


        public void LoadSession()
        {
            strUserId = Session["strUserId"].ToString().Trim();

            strUserName = Session["strUserName"].ToString().Trim();
            strUserEmail = Session["strUserEmail"].ToString().Trim();
            strContactNumber = Session["strContactNumber"].ToString().Trim();

           
        }

        public void EmptySession()
        {

            Session["strUserId"] = "";
            Session["strUserEmail"] = "";         
            Session["strUserName"] = "";
            Session["strContactNumber"] = "";
         

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
        // GET: Reserve
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult ReserveSave(Reserve reserve)
        {

            db.reserves.Add(reserve);
            if (db.SaveChanges() > 0)
            {
                return Json(new { success = true, result = reserve });
            }
            else
            {
                return Json(new { success = false });
            }
            //db.SaveChanges();
            //return Json(new { });

        }

        public JsonResult Reserveshow()
        {
            var lstshow = db.reserves.Where(r=>r.Confirmed == false).ToList();
            return Json(lstshow, JsonRequestBehavior.AllowGet);

        }

        public JsonResult delete(int id)
        {
            Reserve lst = db.reserves.Find(id);
            db.reserves.Remove(lst);
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Confirm(int id)
        {
            var data = db.reserves.Where(em => em.ReserveId == id).FirstOrDefault();

            data.Confirmed = true;

            db.Entry(data).State = System.Data.Entity.EntityState.Modified;


            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(data.Email);
            mail.From = new MailAddress("ruposhibanglacox@gmail.com", "Ruposhi Bangla Coxbazar", System.Text.Encoding.UTF8);

            mail.Subject = "Reservation";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Your Reservation Confirmed";

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

        public JsonResult OrderSave(Order order)
        {

            db.orders.Add(order);
            if (db.SaveChanges() > 0)
            {
                return Json(new { success = true, result = order });
            }
            else
            {
                return Json(new { success = false });
            }
            //db.SaveChanges();
            //return Json(new { });

        }

        public JsonResult OrderConfirmShow(int? id)
        {
            var lstshow = db.menues.Where(r => r.MenueId == id).SingleOrDefault();
            return Json(lstshow, JsonRequestBehavior.AllowGet);


        }


        //public JsonResult CreditCollectionByRange(DateTime Date1, DateTime Date2)
        //{

        //    var data = db.creditCollections.Where(l => l.DateOfCollection >= Date1 && l.DateOfCollection <= Date2).ToList();


        //    return Json(data, JsonRequestBehavior.AllowGet);

        //}


        //public JsonResult CreditCollectionByVehicle(string vehcl)
        //{


        //    var data = db.creditCollections.Where(l => l.VehicleNo == vehcl).ToList();


        //    return Json(data, JsonRequestBehavior.AllowGet);


        //}

        //public JsonResult CreditCollectionByOverDues(string dues)
        //{

        //    var data = db.creditCollections.Where(l => l.PresentStatusOfInStallment == dues).ToList();


        //    return Json(data, JsonRequestBehavior.AllowGet);


        //}

        //public JsonResult CreditCollectionByCustomer(string customr)
        //{

        //    var data = db.creditCollections.Where(l => l.CustomerProfileId == customr).ToList();


        //    return Json(data, JsonRequestBehavior.AllowGet);


        //}
    }
}
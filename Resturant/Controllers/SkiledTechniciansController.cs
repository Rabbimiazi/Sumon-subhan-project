using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    public class SkiledTechniciansController : Controller
    {
        // GET: SkiledTechnicians
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Skiled()
        {
            return View();
        }
        public ActionResult UnSkiled()
        {
            return View();
        }
        public ActionResult SemiSkiled()
        {
            return View();
        }
        public ActionResult HotelCrew()
        {
            return View();
        }
    }
}
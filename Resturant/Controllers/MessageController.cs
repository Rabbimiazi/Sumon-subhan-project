using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MessageFromCAS()
        {
            return View();
        }
        public ActionResult MessageFromMD()
        {
            return View();
        }
         public ActionResult MessageFromGM()
        {
            return View();
        }
        public ActionResult MessageFromAM()
        {
            return View();
        }
    }
}
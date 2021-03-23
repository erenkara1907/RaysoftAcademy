using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class YonetimController : Controller
    {
        // GET: Yonetim
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OturumKapa()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
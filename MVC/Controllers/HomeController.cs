using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC.Models;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ArticleList()
        {
            return View(db.Articles.ToList());
        }

        public
    }
}
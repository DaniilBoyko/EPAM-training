using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Bank application description.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Daniil Boyko contact page.";
            return View();
        }
    }
}
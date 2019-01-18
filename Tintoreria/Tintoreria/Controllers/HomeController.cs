using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string hola = "Hola Mundo";
            return View();
        }
    }
}
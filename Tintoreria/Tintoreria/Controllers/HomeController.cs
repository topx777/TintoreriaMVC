using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            //if(Session["Key"] == null)
            //{
            //   return RedirectToAction("../Login/Index");
            //}

            //ViewBag.Usuario = Session["Key"] as Usuario;



            return View();
        }

    }
}
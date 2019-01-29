using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
//using PagedList;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class TrabajoController : Controller
    {
        // GET: Trabajo
        [HttpGet]
        public ActionResult Index(int? offset)
        {
            int next = 5;

            TrabajoList lista = new TrabajoList();

            lista = TrabajoListBrl.Get(offset.HasValue ? offset.Value : 1, next);

            list

            return View();
        }

        public ActionResult Nuevo()
        {
            
            return View();
        }
    }
}
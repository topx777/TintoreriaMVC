using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        public ActionResult Index()
        {
            CargoListModel lista = CargoListModel.Get();

            return View(lista);
        }
    }
}
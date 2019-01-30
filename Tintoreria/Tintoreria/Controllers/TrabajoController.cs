using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using PagedList;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class TrabajoController : Controller
    {
        // GET: Trabajo
        [HttpGet]
        public ActionResult Index(int? page)
        {
            TrabajoListModel lista = TrabajoListModel.Get(page.HasValue ? page.Value : 1);

            return View(lista);
        }

        public void CargarClientes()
        {
            ViewBag.ListaClientes = new SelectList(
            (
                from t in ClienteController.ListaCliente
                select new SelectListItem
                {
                    Text = t.Nombre + " " + t.Ci,
                    Value = t.IdPersona.ToString()
                }
            )
            , "Value", "Text");
        }

        public ActionResult Nuevo()
        {
            return View();
        }
    }
}
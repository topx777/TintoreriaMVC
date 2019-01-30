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
        public ActionResult Index(int? page, int pageSize = 10)
        {
            var totalItems = TrabajoBrl.Count();
            var totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            var currentPage = page != null ? (int)page : 1;
            var startPage = currentPage - 5;
            var endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            ViewBag.TotalItems = totalItems;
            ViewBag.CurrentPage = currentPage;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalPages = totalPages;
            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;
            
            TrabajoListModel lista = TrabajoListModel.Get(page.HasValue ? page.Value : 1, pageSize);

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
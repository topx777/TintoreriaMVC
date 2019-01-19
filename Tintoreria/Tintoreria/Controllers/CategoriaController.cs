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
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriaListModel lista = CategoriaListModel.Get();

            return View(lista);
        }

        // GET: Crear Categoria
        public ActionResult Crear()
        {
            CategoriaModel categoria = new CategoriaModel();
            return View(categoria);
        }

        // POST : Crear Categoria
        [HttpPost]
        public ActionResult Crear(CategoriaModel model)
        {
            try
            {
                Categoria categoria = new Categoria()
                {
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    Precio = model.Precio
                };

                CategoriaBrl.Insertar(categoria);
                return RedirectToAction("../Categoria/Index");

            }
            catch
            {
                return View();
            }
        }

    }
}
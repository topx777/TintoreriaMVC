using PagedList;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;
using System;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            CategoriaListModel lista = CategoriaListModel.Get();

            IPagedList<CategoriaModel> categorias = null;
            categorias = lista.ToPagedList(pageIndex, pageSize);

            return View(categorias);
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

        // GET: Ver Modificar Categoria
        public ActionResult Editar(int mCodigo)
        {
            Categoria cat = CategoriaBrl.Get(mCodigo);
            CategoriaModel model = new CategoriaModel()
            {
                IdCategoria = cat.IdCategoria,
                Nombre = cat.Nombre,
                Descripcion = cat.Descripcion,
                Precio = cat.Precio
            };

            return View(model);
        }

        //POST: Modificar Categoria
        [HttpPost]
        public ActionResult Editar(int mCodigo, CategoriaModel model)
        {
            try
            {
                Categoria categoria = new Categoria()
                {
                    IdCategoria = mCodigo,
                    Nombre = model.Nombre,
                    Descripcion = model.Descripcion,
                    Precio = model.Precio
                };

                CategoriaBrl.Actualizar(categoria);

                return RedirectToAction("../Categoria/Index");

            }
            catch
            {
                return View();
            }
        }

        //GET Ver Categoria
        public ActionResult Ver(int mCodigo)
        {
            Categoria cat = CategoriaBrl.Get(mCodigo);
            CategoriaModel model = new CategoriaModel()
            {
                IdCategoria = cat.IdCategoria,
                Nombre = cat.Nombre,
                Descripcion = cat.Descripcion,
                Precio = cat.Precio
            };

            return View(model);
        }

        // GET: Categoria/Delete/5
        public ActionResult Eliminar()
        {
            return View();
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Eliminar(int mCodigo)
        {
            try
            {
                // TODO: Add delete logic here

                CategoriaBrl.Eliminar(mCodigo);
                return RedirectToAction("../Categoria/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
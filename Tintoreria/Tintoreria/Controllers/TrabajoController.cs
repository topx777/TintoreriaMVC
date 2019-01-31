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
            CargarCategoria();
            TrabajoModel model = new TrabajoModel();
            model.TrabajoDetalle.Add(new TrabajoDetalleModel());

            return View(model);
        }


        [HttpPost]
        public ActionResult Nuevo(TrabajoModel model, string resp)
        {
            CargarCategoria();
            if (!String.IsNullOrWhiteSpace(resp))
            {
                switch(resp)
                {
                    case "AddTrabajoDetalle":
                        model.TrabajoDetalle.Add(new TrabajoDetalleModel());
                        return View(model);
                    case "Registrar":
                        if (model.FechaEntrega.HasValue && model.Cliente.Ci != null && model.TrabajoDetalle.Count > 0)
                        {
                            Trabajo trabajo = new Trabajo()
                            {
                                FechaEntrega = model.FechaEntrega.Value,
                                Cliente = new Cliente()
                                {
                                    Ci = model.Cliente.Ci
                                }

                            };
                            trabajo.TrabajoDetalle = new List<TrabajoDetalle>();
                            foreach(var trabajod in model.TrabajoDetalle)
                            {
                                trabajo.TrabajoDetalle.Add(new TrabajoDetalle()
                                {
                                    CodigoPrenda = trabajod.CodigoPrenda,
                                    Peso = trabajod.Peso,
                                    Categoria = new Categoria()
                                    {
                                        IdCategoria = trabajod.Categoria.IdCategoria
                                    }
                                });
                            }

                            TrabajoBrl.Insertar(trabajo);

                            return RedirectToAction("../Trabajo/Index");
                        }
                        else
                        {
                            return View(model);
                        }
                    default:
                        return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public void CargarCategoria()
        {
            ViewBag.ListaCategoria = new SelectList((
                from t in CategoriaController.CategoriaList
                select new SelectListItem
                {
                    Text = t.Nombre,
                    Value = t.IdCategoria.ToString()
                }
                ), "Value", "Text");
        }


        [HttpPost]
        public JsonResult VerificarCi(string ci)
        {
            var resultado = new HttpRespuesta();

            try
            {
                Cliente cliente = ClienteBrl.GetCI(ci);

                if(cliente.IdPersona == 0)
                {
                    throw new ApplicationException("No se encontro el cliente");
                }

                resultado.Mensaje = "Cliente encontrado";
                resultado.Ok = true;
            }
            catch(Exception ex)
            {
                resultado.Ok = false;
                resultado.Mensaje = ex.Message;
            }

            return Json(resultado);
        }
    }
}
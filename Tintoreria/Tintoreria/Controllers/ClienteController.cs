using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteListModel lista = ClienteListModel.Get();
            return View(lista);
        }


        // GET: Crear Cliente
        public ActionResult Crear()
        {
            CargarSexo();
            CargarTipo();
            ClienteModel client = new ClienteModel();

            client.Correos = new List<CorreoModel>();
            client.Correos.Add(new CorreoModel());

            client.Telefonos = new List<TelefonoModel>();
            client.Telefonos.Add(new TelefonoModel());

            client.Direcciones = new List<DireccionModel>();
            client.Direcciones.Add(new DireccionModel());

            return View(client);
        }
        public void CargarSexo()
        {
            ViewBag.ListaSexos = new SelectList(
                        (
                            from t in SexoController.ListaSexo
                            select new SelectListItem
                            {
                                Text = t.Nombre,
                                Value = t.IdSexo.ToString()
                            }
                        )
                        , "Value", "Text");
        }
        public void CargarTipo()
        {
            ViewBag.ListaTipo = new SelectList((
                from t in TipoController.TipoList
                select new SelectListItem
                {
                    Text=t.Nombre,
                    Value=t.IdTipo.ToString()
                }
                ), "Value", "Text");
        }

        [HttpPost]
        public ActionResult Crear(ClienteModel cliente, string resp)
        {
            if(!String.IsNullOrWhiteSpace(resp))
            {
                switch (resp)
                {
                    case "AddCorreo":
                        break;
                    case "AddDireccion":

                        break;
                    case "AddTelefono":
 
                        break;
                    case "Registrar":

                        break;
                    default:
                        break;
                }

            }
            return View(cliente);
        }


               // GET: Ver Modificar Cliente
        public ActionResult Editar(int mCodigo)
        {

            return View();
        }


        //GET Ver Cliente
        public ActionResult Ver(int mCodigo)
        {
            return View();
        }

        //GET Eliminar
        public ActionResult Eliminar()
        {
            return View();
        }

    }
}
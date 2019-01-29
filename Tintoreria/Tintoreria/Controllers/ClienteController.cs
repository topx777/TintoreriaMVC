using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

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
            CargarSexo();
            CargarTipo();
            if(!String.IsNullOrWhiteSpace(resp))
            {
                cliente.Correos = new List<CorreoModel>();
                cliente.Correos.Add(new CorreoModel());
                cliente.Direcciones = new List<DireccionModel>();
                cliente.Direcciones.Add(new DireccionModel());
                cliente.Telefonos = new List<TelefonoModel>();
                cliente.Telefonos.Add(new TelefonoModel());
                switch (resp)
                {
                    case "AddCorreo":
                        break;
                    case "AddDireccion":

                        break;
                    case "AddTelefono":

                        break;
                    case "Registrar":
                        Cliente client = new Cliente()
                        {
                            Usuario = new Usuario()
                            {
                                Username = cliente.Usuario.Username,
                                Password = cliente.Usuario.Password,
                                EsAdmin = cliente.Usuario.EsAdmin
                            },
                            Ci = cliente.Ci,
                            Nombre = cliente.Nombre,
                            PrimerApellido = cliente.PrimerApellido,
                            SegundoApellido = cliente.SegundoApellido,
                            Sexo = new Sexo() {
                                IdSexo = cliente.Sexo.IdSexo,
                            },
                            FechaNacimiento = cliente.FechaNacimiento,
                            Nit = cliente.Nit,
                            Razon = cliente.Razon,
                            FechaRegistro = cliente.FechaRegistro
                        };
                        client.Correos = new List<Correo>();
                        foreach (var correo in cliente.Correos)
                        {
                            client.Correos.Add(new Correo(){
                            Nombre=correo.Nombre,
                            Principal=correo.Principal
                            });
                        }

                        client.Direcciones = new List<Direccion>();
                        foreach (var direccion in cliente.Direcciones)
                        {
                            client.Direcciones.Add(new Direccion() {
                                Descripcion=direccion.Descripccion,
                                Tipo=new Tipo()
                                {
                                    IdTipo=direccion.Tipo.IdTipo
                                },
                                Latitud=direccion.Latitud,
                                Longitud=direccion.Latitud

                            });
                        }
                        client.Telefonos = new List<Telefono>();
                        foreach (var telefono in cliente.Telefonos)
                        {
                            client.Telefonos.Add(new Telefono()
                            {
                                Numero=telefono.Numero,
                                Tipo=new Tipo()
                                {
                                    IdTipo=telefono.Tipo.IdTipo
                                }
                            });
                        }

                        ClienteBrl.Insertar(client);
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
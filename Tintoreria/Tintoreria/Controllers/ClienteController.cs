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
        private static List<ClienteModel> clienteList;
        public static List<ClienteModel> ListaCliente
        {

            get
            {
                clienteList = new List<ClienteModel>();
                foreach (var cliente in ClienteBrl.ListCliente())
                {
                    clienteList.Add(new ClienteModel
                    {
                        IdPersona = cliente.IdPersona,
                        Ci = cliente.Ci,
                        Nombre = cliente.Nombre
                    });
                }
                return clienteList;
            }
            set
            {
                clienteList = value;
            }
        }

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
            client.Correos.Add(new CorreoModel());
            client.Telefonos.Add(new TelefonoModel());
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
                switch (resp)
                {
                    case "AddCorreo":
                        cliente.Correos.Add(new CorreoModel());
                        break;
                    case "AddDireccion":
                        cliente.Direcciones.Add(new DireccionModel());
                        break;
                    case "AddTelefono":
                        cliente.Telefonos.Add(new TelefonoModel());
                        break;
                    case "Registrar":
                        {

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
                                Sexo = new Sexo()
                                {
                                    IdSexo = cliente.Sexo.IdSexo,
                                },
                                FechaNacimiento = cliente.FechaNacimiento.Value,
                                Nit = cliente.Nit,
                                Razon = cliente.Razon,
                                FechaRegistro = cliente.FechaRegistro
                            };
                            client.Correos = new List<Correo>();
                            foreach (var correo in cliente.Correos)
                            {
                                client.Correos.Add(new Correo()
                                {
                                    Nombre = correo.Nombre,
                                    Principal = correo.Principal
                                });
                            }

                            client.Direcciones = new List<Direccion>();
                            foreach (var direccion in cliente.Direcciones)
                            {
                                client.Direcciones.Add(new Direccion()
                                {
                                    Descripcion = direccion.Descripccion,
                                    Tipo = new Tipo()
                                    {
                                        IdTipo = direccion.Tipo.IdTipo
                                    },
                                    Latitud = direccion.Latitud,
                                    Longitud = direccion.Latitud

                                });
                            }
                            client.Telefonos = new List<Telefono>();
                            foreach (var telefono in cliente.Telefonos)
                            {
                                client.Telefonos.Add(new Telefono()
                                {
                                    Numero = telefono.Numero,
                                    Tipo = new Tipo()
                                    {
                                        IdTipo = telefono.Tipo.IdTipo
                                    }
                                });
                            }

                            ClienteBrl.Insertar(client);
                          
                        }
                        break;
                    default:
                        break;
                }

            }

            return View(cliente);
        }


               // GET: Ver Modificar Cliente
        public ActionResult Editar(int Id)
        {
            CargarSexo();
            CargarTipo();
            Cliente client=ClienteBrl.Get(Id);
            ClienteModel clientModel = new ClienteModel() {
                IdPersona = client.IdPersona,
                Nit = client.Nit,
                Razon = client.Razon,
                FechaRegistro = client.FechaRegistro,
                Ci=client.Ci,
                Nombre=client.Nombre,
                PrimerApellido=client.PrimerApellido,
                SegundoApellido=client.SegundoApellido,
                Sexo=new SexoModel()
                {
                    IdSexo=client.Sexo.IdSexo,
                    Nombre=client.Sexo.Nombre
                },
                FechaNacimiento=client.FechaNacimiento.Value,
                Usuario=new UsuarioModel()
                {
                    IdUsuario=client.Usuario.IdUsuario,
                    Username=client.Usuario.Username,
                    Password=client.Usuario.Password,
                    EsAdmin=client.Usuario.EsAdmin
                }
            };
            foreach (var telefono in client.Telefonos)
            {
                clientModel.Telefonos.Add(new TelefonoModel()
                {
                    IdTelefono=telefono.IdTelefono,
                    Numero=telefono.Numero,
                    Tipo=new TipoModel()
                    {
                        IdTipo=telefono.Tipo.IdTipo,
                        Nombre=telefono.Tipo.Nombre
                    }
                });
            }

            foreach (var direccion in client.Direcciones)
            {
                clientModel.Direcciones.Add(new DireccionModel() {
                    IdDireccion=direccion.IdDireccion,
                    Descripccion=direccion.Descripcion,
                    Tipo=new TipoModel()
                    {
                        IdTipo=direccion.Tipo.IdTipo,
                        Nombre=direccion.Tipo.Nombre,
                    },
                    Latitud=direccion.Latitud,
                    Longitud=direccion.Longitud
                });
            }

            foreach (var correo in client.Correos)
            {
                clientModel.Correos.Add(new CorreoModel() {
                    idCorreo=correo.IdCorreo,
                    Nombre=correo.Nombre,
                    Principal=correo.Principal
                });
            }

            return View(clientModel);
        }

        [HttpPost]
        public ActionResult Editar(ClienteModel clientM, string resp)
        {

            if (!String.IsNullOrWhiteSpace(resp))
            {
                switch (resp)
                {
                    case "AddCorreo":
                        clientM.Correos.Add(new CorreoModel());
                        break;
                    case "AddDireccion":
                        clientM.Direcciones.Add(new DireccionModel());
                        break;
                    case "AddTelefono":
                        clientM.Telefonos.Add(new TelefonoModel());
                        break;
                    case "Cancelar":
                        break;
                    case "Actulizar":
                        {
                            Cliente cliente = new Cliente()
                            {
                                IdPersona = clientM.IdPersona,
                                Ci = clientM.Ci,
                                Nombre = clientM.Nombre,
                                PrimerApellido = clientM.PrimerApellido,
                                SegundoApellido = clientM.SegundoApellido,
                                Sexo = new Sexo()
                                {
                                    IdSexo = clientM.Sexo.IdSexo,
                                    Nombre = clientM.Sexo.Nombre
                                },
                                FechaNacimiento = clientM.FechaNacimiento,
                                Usuario = new Usuario()
                                {
                                    IdUsuario = clientM.Usuario.IdUsuario,
                                    Username = clientM.Usuario.Username,
                                    Password = clientM.Usuario.Password,
                                    EsAdmin = clientM.Usuario.EsAdmin
                                },
                                Nit = clientM.Nit,
                                Razon = clientM.Razon,
                                FechaRegistro = clientM.FechaRegistro
                            };
                            cliente.Telefonos = new List<Telefono>();
                            foreach (var telefono in clientM.Telefonos)
                            {
                                cliente.Telefonos.Add(new Telefono()
                                {
                                    IdTelefono = telefono.IdTelefono,
                                    Numero = telefono.Numero,
                                    Tipo = new Tipo()
                                    {
                                        IdTipo = telefono.Tipo.IdTipo,
                                        Nombre = telefono.Tipo.Nombre
                                    }

                                });
                            }
                            cliente.Direcciones = new List<Direccion>();
                            foreach (var direccion in clientM.Direcciones)
                            {
                                cliente.Direcciones.Add(new Direccion()
                                {
                                    IdDireccion = direccion.IdDireccion,
                                    Descripcion = direccion.Descripccion,
                                    Tipo = new Tipo()
                                    {
                                        IdTipo = direccion.Tipo.IdTipo,
                                        Nombre = direccion.Tipo.Nombre
                                    },
                                    Latitud = direccion.Latitud,
                                    Longitud = direccion.Longitud
                                });
                            }
                            cliente.Correos = new List<Correo>();
                            foreach (var correo in clientM.Correos)
                            {
                                cliente.Correos.Add(new Correo()
                                {
                                    IdCorreo = correo.idCorreo,
                                    Nombre = correo.Nombre,
                                    Principal = correo.Principal
                                });
                            }
                                ClienteBrl.Actualizar(cliente);
                        }
                        break;
                }
            }

            
            return RedirectToAction("../Cliente/Index");
        }

        //GET Ver Cliente
        public ActionResult Ver(int Id)
        {
            CargarSexo();
            CargarTipo();
            Cliente client = ClienteBrl.Get(Id);
            ClienteModel clientModel = new ClienteModel()
            {
                IdPersona = client.IdPersona,
                Nit = client.Nit,
                Razon = client.Razon,
                FechaRegistro = client.FechaRegistro,
                Ci = client.Ci,
                Nombre = client.Nombre,
                PrimerApellido = client.PrimerApellido,
                SegundoApellido = client.SegundoApellido,
                Sexo = new SexoModel()
                {
                    IdSexo = client.Sexo.IdSexo,
                    Nombre = client.Sexo.Nombre
                },
                FechaNacimiento = client.FechaNacimiento.Value,
                Usuario = new UsuarioModel()
                {
                    IdUsuario = client.Usuario.IdUsuario,
                    Username = client.Usuario.Username,
                    Password = client.Usuario.Password,
                    EsAdmin = client.Usuario.EsAdmin
                }
            };
            foreach (var telefono in client.Telefonos)
            {
                clientModel.Telefonos.Add(new TelefonoModel()
                {
                    IdTelefono = telefono.IdTelefono,
                    Numero = telefono.Numero,
                    Tipo = new TipoModel()
                    {
                        IdTipo = telefono.Tipo.IdTipo,
                        Nombre = telefono.Tipo.Nombre
                    }
                });
            }

            foreach (var direccion in client.Direcciones)
            {
                clientModel.Direcciones.Add(new DireccionModel()
                {
                    IdDireccion = direccion.IdDireccion,
                    Descripccion = direccion.Descripcion,
                    Tipo = new TipoModel()
                    {
                        IdTipo = direccion.Tipo.IdTipo,
                        Nombre = direccion.Tipo.Nombre,
                    },
                    Latitud = direccion.Latitud,
                    Longitud = direccion.Longitud
                });
            }

            foreach (var correo in client.Correos)
            {
                clientModel.Correos.Add(new CorreoModel()
                {
                    idCorreo = correo.IdCorreo,
                    Nombre = correo.Nombre,
                    Principal = correo.Principal
                });
            }

            return View(clientModel);

        }
        [HttpPost]
        public ActionResult Ver()
        {
            return RedirectToAction("../Cliente/Index");
        }

        //GET Eliminar
        public ActionResult Eliminar(int Id)
        {
            CargarSexo();
            CargarTipo();
            Cliente client = ClienteBrl.Get(Id);
            ClienteModel clientModel = new ClienteModel()
            {
                IdPersona = client.IdPersona,
                Nit = client.Nit,
                Razon = client.Razon,
                FechaRegistro = client.FechaRegistro,
                Ci = client.Ci,
                Nombre = client.Nombre,
                PrimerApellido = client.PrimerApellido,
                SegundoApellido = client.SegundoApellido,
                Sexo = new SexoModel()
                {
                    IdSexo = client.Sexo.IdSexo,
                    Nombre = client.Sexo.Nombre
                },
                FechaNacimiento = client.FechaNacimiento.Value,
                Usuario = new UsuarioModel()
                {
                    IdUsuario = client.Usuario.IdUsuario,
                    Username = client.Usuario.Username,
                    Password = client.Usuario.Password,
                    EsAdmin = client.Usuario.EsAdmin
                }
            };
            foreach (var telefono in client.Telefonos)
            {
                clientModel.Telefonos.Add(new TelefonoModel()
                {
                    IdTelefono = telefono.IdTelefono,
                    Numero = telefono.Numero,
                    Tipo = new TipoModel()
                    {
                        IdTipo = telefono.Tipo.IdTipo,
                        Nombre = telefono.Tipo.Nombre
                    }
                });
            }

            foreach (var direccion in client.Direcciones)
            {
                clientModel.Direcciones.Add(new DireccionModel()
                {
                    IdDireccion = direccion.IdDireccion,
                    Descripccion = direccion.Descripcion,
                    Tipo = new TipoModel()
                    {
                        IdTipo = direccion.Tipo.IdTipo,
                        Nombre = direccion.Tipo.Nombre,
                    },
                    Latitud = direccion.Latitud,
                    Longitud = direccion.Longitud
                });
            }

            foreach (var correo in client.Correos)
            {
                clientModel.Correos.Add(new CorreoModel()
                {
                    idCorreo = correo.IdCorreo,
                    Nombre = correo.Nombre,
                    Principal = correo.Principal
                });
            }

            return View(clientModel);

        }

        [HttpPost]
        public ActionResult Eliminar(ClienteModel clientM, string resp)
        {
            if (!String.IsNullOrWhiteSpace(resp))
            {
                switch (resp)
                {
                    case "Cancelar":
                        break;
                    case "Borrar":
                        ClienteBrl.Eliminar(clientM.IdPersona);
                        break;
                }
            }
            return RedirectToAction("../Cliente/Index");

        }

        public static Cliente mClientToClient(ClienteModel clientM)
        {
            Cliente cliente = new Cliente()
            {
                IdPersona = clientM.IdPersona,
                Nit = clientM.Nit,
                Razon = clientM.Razon,
                FechaRegistro = clientM.FechaRegistro,
                Ci = clientM.Ci,
                Nombre = clientM.Nombre,
                PrimerApellido = clientM.PrimerApellido,
                SegundoApellido = clientM.SegundoApellido,
                Sexo = new Sexo()
                {
                    IdSexo = clientM.Sexo.IdSexo,
                    Nombre = clientM.Sexo.Nombre
                },
                FechaNacimiento = clientM.FechaNacimiento.Value,
                Usuario = new Usuario()
                {
                    IdUsuario = clientM.Usuario.IdUsuario,
                    Username = clientM.Usuario.Username,
                    Password = clientM.Usuario.Password,
                    EsAdmin = clientM.Usuario.EsAdmin
                }
            };
            foreach (var telefono in clientM.Telefonos)
            {
                cliente.Telefonos.Add(new Telefono()
                {
                    IdTelefono = telefono.IdTelefono,
                    Numero = telefono.Numero,
                    Tipo = new Tipo()
                    {
                        IdTipo = telefono.Tipo.IdTipo,
                        Nombre = telefono.Tipo.Nombre
                    }
                });
            }

            foreach (var direccion in clientM.Direcciones)
            {
                cliente.Direcciones.Add(new Direccion()
                {
                    IdDireccion = direccion.IdDireccion,
                    Descripcion = direccion.Descripccion,
                    Tipo = new Tipo()
                    {
                        IdTipo = direccion.Tipo.IdTipo,
                        Nombre = direccion.Tipo.Nombre,
                    },
                    Latitud = direccion.Latitud,
                    Longitud = direccion.Longitud
                });
            }

            foreach (var correo in clientM.Correos)
            {
                cliente.Correos.Add(new Correo()
                {
                    IdCorreo = correo.idCorreo,
                    Nombre = correo.Nombre,
                    Principal = correo.Principal
                });
            }
            return cliente;

        }


        //Prueba metodo AJAX
        [HttpPost]
        public JsonResult NuevoAJAX(Categoria categoria)
        {
            Categoria cate = new Categoria()
            {
                IdCategoria = categoria.IdCategoria,
                Nombre = categoria.Nombre,
                Descripcion = categoria.Descripcion,
                Precio = categoria.Precio
            };
            return Json(cate.Nombre);
        }

    }
}
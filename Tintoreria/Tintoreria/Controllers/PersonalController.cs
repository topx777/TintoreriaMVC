using PagedList;
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
    public class PersonalController : Controller
    {
        // GET: Personal
        [HttpGet]
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            PersonalListModel lista = PersonalListModel.Get();

            IPagedList<PersonalModel> personal = null;
            personal = lista.ToPagedList(pageIndex, pageSize);

            return View(personal);
        }

        // GET: Crear Personal
        public ActionResult Crear()
        {
            CargarSexo();
            CargarTipo();
            CargarCargo();
            PersonalModel personM = new PersonalModel ();
            personM.Correos.Add(new CorreoModel());
            personM.Telefonos.Add(new TelefonoModel());
            personM.Direcciones.Add(new DireccionModel());

            return View(personM);
        }

        [HttpPost]
        public ActionResult Crear(PersonalModel personalM, string resp)
        {

            CargarSexo();
            CargarTipo();
            CargarCargo();
            if (!String.IsNullOrWhiteSpace(resp))
            {
                switch (resp)
                {
                    case "AddCorreo":
                        personalM.Correos.Add(new CorreoModel());
                        break;
                    case "AddDireccion":
                        personalM.Direcciones.Add(new DireccionModel());
                        break;
                    case "AddTelefono":
                        personalM.Telefonos.Add(new TelefonoModel());
                        break;
                    case "Registrar":
                        {

                            Personal person = new Personal()
                            {
                                Usuario = new Usuario()
                                {
                                    Username = personalM.Usuario.Username,
                                    Password = personalM.Usuario.Password,
                                    EsAdmin = personalM.Usuario.EsAdmin
                                },
                                Ci = personalM.Ci,
                                Nombre = personalM.Nombre,
                                PrimerApellido = personalM.PrimerApellido,
                                SegundoApellido = personalM.SegundoApellido,
                                Sexo = new Sexo()
                                {
                                    IdSexo = personalM.Sexo.IdSexo,
                                },
                                FechaNacimiento = personalM.FechaNacimiento.Value,
                                CodPersonal = personalM.CodPersonal,
                                Sueldo = personalM.Sueldo,
                                FechaIngreso = personalM.FechaIngreso,

                                Cargo = new Cargo()
                                {
                                    IdCargo = personalM.Cargo.IdCargo,
                                    Nombre = personalM.Cargo.Nombre
                                },
                            };
                            person.Correos = new List<Correo>();
                            foreach (var correo in personalM.Correos)
                            {
                                person.Correos.Add(new Correo()
                                {
                                    Nombre = correo.Nombre,
                                    Principal = correo.Principal
                                });
                            }

                            person.Direcciones = new List<Direccion>();
                            foreach (var direccion in personalM.Direcciones)
                            {
                                person.Direcciones.Add(new Direccion()
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
                            person.Telefonos = new List<Telefono>();
                            foreach (var telefono in personalM.Telefonos)
                            {
                                person.Telefonos.Add(new Telefono()
                                {
                                    Numero = telefono.Numero,
                                    Tipo = new Tipo()
                                    {
                                        IdTipo = telefono.Tipo.IdTipo
                                    }
                                });
                            }

                            PersonalBrl.Insertar(person);

                        }
                        break;
                    default:
                        break;
                }

            }

            return View(personalM);

        }

        public void CargarTipo()
        {
            ViewBag.ListaTipo = new SelectList(
            (
                from t in TipoController.TipoList
                select new SelectListItem
                {
                    Text = t.Nombre,
                    Value = t.IdTipo.ToString()
                }
           )
           , "Value", "Text");
        }

        public void CargarCargo()
        {
            ViewBag.ListaCargo = new SelectList(
            (
                from t in CargoController.CargoList
                select new SelectListItem
                {
                    Text = t.Nombre,
                    Value = t.IdCargo.ToString()
                }
           )
           , "Value", "Text");
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




        //ver personal
        public ActionResult Ver(int Id)
        {
            Personal per = PersonalBrl.Get(Id);
            PersonalModel model = new PersonalModel()
            {
                IdPersona = per.IdPersona,
                Ci=per.Ci,
                Nombre= per.Nombre,
                PrimerApellido=per.PrimerApellido,
                SegundoApellido=per.SegundoApellido,
            };

            return View(model);
        }

        //Borrado personal
        public ActionResult Eliminar(int Id)
        {
            CargarSexo();
            CargarTipo();
            Personal person = PersonalBrl.Get(Id);
            PersonalModel personalModel = new PersonalModel()
            {
                IdPersona = person.IdPersona,
                FechaIngreso = person.FechaIngreso,
                Ci = person.Ci,
                Nombre = person.Nombre,
                PrimerApellido = person.PrimerApellido,
                SegundoApellido = person.SegundoApellido,
                Sexo = new SexoModel()
                {
                    IdSexo = person.Sexo.IdSexo,
                    Nombre = person.Sexo.Nombre
                },
                FechaNacimiento = person.FechaNacimiento.Value,
                Usuario = new UsuarioModel()
                {
                    IdUsuario = person.Usuario.IdUsuario,
                    Username = person.Usuario.Username,
                    Password = person.Usuario.Password,
                    EsAdmin = person.Usuario.EsAdmin
                },
                CodPersonal=person.CodPersonal,

                Cargo=new CargoModel()
                {
                    IdCargo=person.Cargo.IdCargo,
                    Nombre=person.Cargo.Nombre,
                },

               Sueldo=person.Sueldo,
                
            };
            foreach (var telefono in person.Telefonos)
            {
                personalModel.Telefonos.Add(new TelefonoModel()
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

            foreach (var direccion in person.Direcciones)
            {
                personalModel.Direcciones.Add(new DireccionModel()
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

            foreach (var correo in person.Correos)
            {
                personalModel.Correos.Add(new CorreoModel()
                {
                    idCorreo = correo.IdCorreo,
                    Nombre = correo.Nombre,
                    Principal = correo.Principal
                });
            }

            return View(personalModel);

        }

        [HttpPost]
        public ActionResult Eliminar(PersonalModel clientM, string resp)
        {
            if (!String.IsNullOrWhiteSpace(resp))
            {
                switch (resp)
                {
                    case "Cancelar":
                        break;
                    case "Borrar":
                        PersonalBrl.Eliminar(clientM.IdPersona);
                        break;
                }
            }
            return RedirectToAction("../Personal/Index");

        }

        //Editar personal
        public ActionResult Editar(int Id)
        {
            CargarSexo();
            CargarTipo();
            Personal person = PersonalBrl.Get(Id);
            PersonalModel personM = new PersonalModel()
            {
                IdPersona = person.IdPersona,
                FechaNacimiento = person.FechaNacimiento,
                Ci = person.Ci,
                Nombre = person.Nombre,
                PrimerApellido = person.PrimerApellido,
                SegundoApellido = person.SegundoApellido,
                Sexo = new SexoModel()
                {
                    IdSexo = person.Sexo.IdSexo,
                    Nombre = person.Sexo.Nombre
                },
                
                Usuario = new UsuarioModel()
                {
                    IdUsuario = person.Usuario.IdUsuario,
                    Username = person.Usuario.Username,
                    Password = person.Usuario.Password,
                    EsAdmin = person.Usuario.EsAdmin
                }
            };
            foreach (var telefono in person.Telefonos)
            {
                personM.Telefonos.Add(new TelefonoModel()
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

            foreach (var direccion in person.Direcciones)
            {
                personM.Direcciones.Add(new DireccionModel()
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

            foreach (var correo in person.Correos)
            {
                personM.Correos.Add(new CorreoModel()
                {
                    idCorreo = correo.IdCorreo,
                    Nombre = correo.Nombre,
                    Principal = correo.Principal
                });
            }

            return View(personM);
        }

        [HttpPost]
        public ActionResult Editar(PersonalModel personaMod, string resp)
        {

            if (!String.IsNullOrWhiteSpace(resp))
            {
                switch (resp)
                {
                    case "AddCorreo":
                        personaMod.Correos.Add(new CorreoModel());
                        break;
                    case "AddDireccion":
                        personaMod.Direcciones.Add(new DireccionModel());
                        break;
                    case "AddTelefono":
                        personaMod.Telefonos.Add(new TelefonoModel());
                        break;
                    case "Cancelar":
                        break;
                    case "Actulizar":
                        {
                            Personal personal = new Personal()
                            {
                                CodPersonal = personaMod.CodPersonal,
                                FechaIngreso=personaMod.FechaIngreso,
                                Cargo = new Cargo()
                                {
                                    IdCargo = personaMod.Cargo.IdCargo,
                                    Nombre = personaMod.Cargo.Nombre
                                },
                                Sueldo=personaMod.Sueldo,

                                Nombre= personaMod.Nombre,
                                PrimerApellido = personaMod.PrimerApellido,
                                SegundoApellido = personaMod.SegundoApellido,
                                Sexo = new Sexo()
                                {
                                    IdSexo = personaMod.Sexo.IdSexo,
                                    Nombre = personaMod.Sexo.Nombre
                                },
                                FechaNacimiento = personaMod.FechaNacimiento,
                                Usuario = new Usuario()
                                {
                                    IdUsuario = personaMod.Usuario.IdUsuario,
                                    Username = personaMod.Usuario.Username,
                                    Password = personaMod.Usuario.Password,
                                    EsAdmin = personaMod.Usuario.EsAdmin
                                },
                                
                            };
                            personal.Telefonos = new List<Telefono>();
                            foreach (var telefono in personaMod.Telefonos)
                            {
                                personal.Telefonos.Add(new Telefono()
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
                            personal.Direcciones = new List<Direccion>();
                            foreach (var direccion in personaMod.Direcciones)
                            {
                                personal.Direcciones.Add(new Direccion()
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
                            personal.Correos = new List<Correo>();
                            foreach (var correo in personaMod.Correos)
                            {
                                personal.Correos.Add(new Correo()
                                {
                                    IdCorreo = correo.idCorreo,
                                    Nombre = correo.Nombre,
                                    Principal = correo.Principal
                                });
                            }
                            PersonalBrl.Actualizar(personal);
                        }
                        break;
                }
            }


            return RedirectToAction("../Personal/Index");
        }
    }
}
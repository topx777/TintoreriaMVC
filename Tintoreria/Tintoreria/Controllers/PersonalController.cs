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
            PersonalModel personal = new PersonalModel();

            personal.Correos = new List<CorreoModel>();
            personal.Correos.Add(new CorreoModel());

            personal.Telefonos = new List<TelefonoModel>();
            personal.Telefonos.Add(new TelefonoModel());

            personal.Direcciones = new List<DireccionModel>();
            personal.Direcciones.Add(new DireccionModel());

            return View(personal);
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

        [HttpPost]
        public ActionResult Crear(PersonalModel model)
        {

            Personal per = new Personal()
            {
                IdPersona = model.IdPersona,
                Ci = model.Ci,
                Nombre = model.Nombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                Sexo = new Sexo()
                {
                    IdSexo = model.Sexo.IdSexo,
                    Nombre = model.Sexo.Nombre
                },
                FechaNacimiento = model.FechaNacimiento.Value,
                CodPersonal = model.CodPersonal,
                FechaIngreso = model.FechaIngreso,
                Sueldo = model.Sueldo,
                Correos = null,
                Telefonos = null,
                Direcciones = null,
                Cargo = new Cargo()
                {
                    IdCargo = model.Cargo.IdCargo,
                    Nombre = model.Cargo.Nombre
                },
                Borrado = model.Borrado,
                Usuario = new Usuario()
                {
                    IdUsuario = model.Usuario.IdUsuario,
                    Username = model.Usuario.Username,
                    Password = model.Usuario.Password,
                    EsAdmin = model.Usuario.EsAdmin
                }
            };

            try
            {
                PersonalBrl.Insertar(per);

                return RedirectToAction("../Personal/Index");
            }
            catch
            {
                return View(model);
            }

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

        
    }
}
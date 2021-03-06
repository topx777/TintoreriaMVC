﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class CargoController : Controller
    {
        private static List<CargoModel> ListCargo;

        public static List<CargoModel> CargoList
        {
            get
            {
                var ListCargo = new List<CargoModel>();
                foreach (var cargo in CargoBrl.Get())
                {
                    ListCargo.Add(new CargoModel
                    {
                        IdCargo = cargo.IdCargo,
                        Nombre = cargo.Nombre
                    });
                }
                return ListCargo;
            }
            set
            {
                ListCargo = value;
            }
        }

        // GET: Cargo
        public ActionResult Index()
        {
            if (Session["Key"] == null)
            {
                return RedirectToAction("../Login/Index");
            }

            CargoListModel lista = CargoListModel.Get();

            return View(lista);
        }
        // GET: Crear Cargo
        public ActionResult Crear()
        {
            if (Session["Key"] == null)
            {
                return RedirectToAction("../Login/Index");
            }

            CargoModel cargo = new CargoModel();
            return View(cargo);
        }
        // POST : Crear Cargo
        [HttpPost]
        public ActionResult Crear(CargoModel model)
        {
            try
            {
                Cargo cargo = new Cargo()
                {
                    Nombre = model.Nombre,
                };

                CargoBrl.Insertar(cargo);
                return RedirectToAction("../Cargo/Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ver Modificar Cargo
        public ActionResult Editar(int mCodigo)
        {
            if (Session["Key"] == null)
            {
                return RedirectToAction("../Login/Index");
            }

            Cargo car = CargoBrl.Get(mCodigo);
            CargoModel model = new CargoModel()
            {
                IdCargo = car.IdCargo,
                Nombre = car.Nombre,
            };

            return View(model);
        }

        //POST: Modificar Cargo
        [HttpPost]
        public ActionResult Editar(int mCodigo, CargoModel model)
        {
            try
            {
                Cargo cargo = new Cargo()
                {
                    IdCargo = mCodigo,
                    Nombre = model.Nombre,
                };

                CargoBrl.Actualizar(cargo);

                return RedirectToAction("../Cargo/Index");

            }
            catch
            {
                return View();
            }
        }

        //GET Ver Categoria
        public ActionResult Ver(int mCodigo)
        {
            if (Session["Key"] == null)
            {
                return RedirectToAction("../Login/Index");
            }

            Cargo car = CargoBrl.Get(mCodigo);
            CargoModel model = new CargoModel()
            {
                IdCargo = car.IdCargo,
                Nombre = car.Nombre,

            };

            return View(model);
        }

        // GET: Cargo/Delete
        public ActionResult Eliminar()
        {
            if (Session["Key"] == null)
            {
                return RedirectToAction("../Login/Index");
            }

            return View();
        }

        // POST: Categoria/Delete
        [HttpPost]
        public ActionResult Eliminar(int mCodigo)
        {
            try
            {
                // TODO: Add delete logic here

                CargoBrl.Eliminar(mCodigo);
                return RedirectToAction("../Cargo/Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
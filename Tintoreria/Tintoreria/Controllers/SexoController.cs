using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class SexoController : Controller
    {
        private static List<SexoModel> sexoList;
        public static List<SexoModel> ListaSexo
        {

            get {
                sexoList = new List<SexoModel>();
                foreach (var sexo in SexoBrl.Get() )
                {
                    sexoList.Add(new SexoModel
                    {
                        IdSexo = sexo.IdSexo,
                        Nombre = sexo.Nombre
                    });
                }
                return sexoList;
            }
            set {
                sexoList = value;
            }
        }

        
        // GET: Sexo
        public ActionResult Index()
        {
            return View();
        }
    }
}
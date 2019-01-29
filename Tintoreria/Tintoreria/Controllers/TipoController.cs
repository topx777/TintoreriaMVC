using System.Collections.Generic;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class TipoController : Controller
    {
        private static List<TipoModel> ListTipo;

        public static List<TipoModel> TipoList
        {

            get
            {
                var ListTipo = new List<TipoModel>();
                foreach (var tipo in TipoBrl.Get())
                {
                    ListTipo.Add(new TipoModel
                    {
                        IdTipo=tipo.IdTipo,
                        Nombre=tipo.Nombre
                    });
                }
                return ListTipo;
            }
            set
            {
                ListTipo = value;
            }
        }

        // GET: Tipo
        public ActionResult Index()
        {
            return View();
        }
    }
}
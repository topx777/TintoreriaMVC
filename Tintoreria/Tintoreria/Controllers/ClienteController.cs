using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteListModel lista = new ClienteListModel();
            return View(lista);
        }


        // GET: Crear Cliente
        public ActionResult Crear()
        {
            ClienteModel client = new ClienteModel();
            return View(client);
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
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
            return View();
        }
    }
}
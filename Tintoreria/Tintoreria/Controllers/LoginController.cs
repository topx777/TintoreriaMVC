using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            UsuarioModel model = new UsuarioModel();

            return View(model);
        }

        // POST: Login
        [HttpPost]
        public ActionResult Index(UsuarioModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Usuario usuario = UsuarioBrl.Auth(model.Username, model.Password);
                    if (usuario != null)
                    {

                        return RedirectToAction("../Categoria/Index");
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
using reCAPTCHA.MVC;
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
            ViewBag.Error = "";
            UsuarioModel model = new UsuarioModel();

            return View(model);
        }

        // POST: Login
        [HttpPost]
        [CaptchaValidator(
            PrivateKey = "6LeT6IwUAAAAAG7CzrIo3l_URg0DdtfprrPPMTrr",
            ErrorMessage = "Error captcha invalido.",
            RequiredMessage = "El captcha es requerido")]
        public ActionResult Index(UsuarioModel model, bool captchaValid)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Usuario usuario = UsuarioBrl.Auth(model.Username, model.Password);
                    if (usuario.IdUsuario != 0)
                    {
                        Session["Key"] = usuario;
                        return RedirectToAction("../Home/Index");
                    }
                    else
                    {
                        ViewBag.Error = "Credenciales Incorrectas";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.Error = "Error, No se pudo iniciar Sesion";
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                ViewBag.Error = "Error Desconocido: " + ex.Message;
                return View(model);
            }
        }


        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("../Login/Index");
        } 

    }
}
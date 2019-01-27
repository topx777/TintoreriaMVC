using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class CorreoModel
    {
        [Display(Name ="Id Correo")]
        public int idCorreo { get; set; }

        [Display(Name="Nombre")]
        public string Nombre { get; set; }

        [Display(Name ="Principal")]
        public bool Principal { get; set; }
    }
}
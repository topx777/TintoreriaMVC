using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class TipoModel
    {
        [Display(Name ="Id Tipo")]
        public int IdTipo { get; set; }

        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
    }
}
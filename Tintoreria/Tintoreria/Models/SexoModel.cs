using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class SexoModel
    {
        [Display(Name ="Id Sexo")]
        public int IdSexo { get; set; }

        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
    }
}
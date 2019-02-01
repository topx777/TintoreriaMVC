using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class TelefonoModel
    {
        [Display(Name = "Id Telefono")]
        public int IdTelefono { get; set; }

        [Required(ErrorMessage ="El campo numero es Requerido")]
        [Display(Name = "Numero")]
        [StringLength(8,ErrorMessage ="El campo debe contener como maximo 8")]
        public string Numero { get; set; }

        [Display(Name = "Tipo")]
        public TipoModel Tipo { get; set; }
    }
}
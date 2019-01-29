using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class EstadoModel
    {
        #region Atributos
        [Key]
        [Display(Name = "ID")]
        public int IdEstado { get; set; }

        [Display(Name = "Nombre de Estado")]
        [StringLength(25, ErrorMessage = "Numero maximo de caracteres 25")]
        public string Nombre { get; set; }
        #endregion
    }
}
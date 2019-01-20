using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class CategoriaModel
    {
        #region Propiedades

        [Display (Name = "ID")]
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Campo nombre no debe estar vacio.")]
        [Display(Name = "Nombre")]
        [StringLength(50, ErrorMessage = "El Campo nombre no debe sobrepasar los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo descripcion no debe estar vacio.")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "El rango del precio es invalido.")]
        [Display(Name = "Precio")]
        public double Precio { get; set; }

        #endregion
    }
}
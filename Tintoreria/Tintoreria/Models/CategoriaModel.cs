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

        [Required(ErrorMessage = "Campo precio no debe estar vacio.")]
        [Display(Name = "Precio")]
        [Range(0, 99999999.99, ErrorMessage = "El rango del precio es invalido.")]
        public double Precio { get; set; }

        #endregion
    }
}
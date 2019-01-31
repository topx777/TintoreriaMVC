using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class TrabajoDetalleModel
    {

        #region Atributos
        [Key]
        [Display(Name = "ID")]
        public int IdTrabajoDetalle { get; set; }

        [Display(Name = "Cod Prenda")]
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "El campo debe contener entre 3 y 25 caracteres")]
        public string CodigoPrenda { get; set; }
      
        public CategoriaModel Categoria { get; set; }

        [Display(Name = "Precio Final")]
        [Range(0, 99999999.99, ErrorMessage = "Precio debe ser mayor a 0")]
        public decimal PrecioFinal { get; set; }

        [Display(Name = "Peso")]
        [Required(ErrorMessage = "El campo es requeridos")]
        [Range(0, 99999999.99, ErrorMessage = "Peso debe ser mayor a 0")]
        public double Peso { get; set; }

        public EstadoModel Estado { get; set; }

        [Display(Name = "Borrado")]
        public bool Borrado { get; set; }
        #endregion

    }
}
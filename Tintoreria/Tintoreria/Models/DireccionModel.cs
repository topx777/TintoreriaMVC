using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class DireccionModel
    {
        [Display(Name ="Id Direccion")]
        public int IdDireccion { get; set; }

        [Required(ErrorMessage ="El Campo de Descripcion no puede ser vacio")]
        [Display(Name ="Descripccion")]
        [StringLength(150,MinimumLength =10, ErrorMessage ="El Campo Descripccion debe contener entre 10 y 150 caracteres")]
        public string Descripccion { get; set; }

        [Display(Name = "Tipo")]
        public TipoModel Tipo { get; set; }

        [Display(Name ="Latitud")]
        
        public double Latitud { get; set; }

        [Display(Name ="Longitud")]
        public double Longitud { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class PersonalModel : PersonaModel
    {
        [Display(Name = "Codigo")]
        public int CodPersonal { get; set; }

        [Display(Name = "Fecha Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Campo cargo no debe estar vacio.")]
        [Display(Name = "Cargo")]
        public CargoModel Cargo { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "El rango del sueldo es invalido.")]
        [Display(Name = "Sueldo")]
        public double Sueldo { get; set; }
    }
}
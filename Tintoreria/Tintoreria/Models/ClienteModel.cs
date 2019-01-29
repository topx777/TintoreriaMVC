using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class ClienteModel:PersonaModel
    {
        public ClienteModel()
        {
            this.Direcciones = new List<DireccionModel>();
            this.Telefonos = new List<TelefonoModel>();
            this.Correos = new List<CorreoModel>();
        }

        #region Propiedades
        [Required(ErrorMessage ="El campo Nit es Requerido")]
        [StringLength(25,MinimumLength = 1, ErrorMessage ="El Campo Nit debe tener como minimo 10 Caracteres")]
        [Display(Name ="Nit")]
        public string Nit { get; set; }

        [Required(ErrorMessage ="El Campo Razon es Requerido")]
        [Display(Name ="Razon")]
        public string Razon { get; set; }

        [Display(Name ="Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class ClienteModel
    {
        #region Propiedades

        [Display(Name ="IdPersona")]
        public int IdPersona { get; set; }

        [Display(Name ="Ci")]
        public string Ci { get; set; }

        [Display(Name="Nombre")]
        public string Nombre { get; set; }

        [Display(Name ="Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Display(Name ="Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Display(Name ="Sexo")]
        public SexoModel Sexo { get; set; }

        [Display(Name ="Fecha Nacimiento")]
        public DateTime? FechaNacimiento { get; set; }

        [Display(Name ="Correos")]
        public List<Correo> Correos { get; set; }

        [Display(Name ="Username")]
        public string Username { get; set; }

        [Display(Name ="Password")]
        public string Password { get; set; }

        [Display(Name ="Es Administrador")]
        public bool EsAdmin { get; set; }

        [Display(Name ="Direcciones")]
        public List<Direccion> Direcciones { get; set; }

        [Display(Name ="Telefonos")]
        public List<Telefono> Telefonos { get; set; }

        [Display(Name ="Nit")]
        public string Nit { get; set; }

        [Display(Name ="Razon")]
        public string Razon { get; set; }

        [Display(Name ="Fecha Registro")]
        public DateTime FechaRegistro { get; set; }

        #endregion
    }
}
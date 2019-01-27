using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class PersonaModel
    {
        [Display(Name = "ID")]
        public int IdPersona { get; set; }

        [Required(ErrorMessage = "Campo ci no debe estar vacio.")]
        [Display(Name = "Ci")]
        [StringLength(15, ErrorMessage = "El Campo Ci no debe sobrepasar los 15 numeros.")]
        public string Ci { get; set; }

        [Required(ErrorMessage = "Campo nombre no debe estar vacio.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Campo apellido no debe estar vacio.")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "Campo apellido no debe estar vacio.")]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "Campo sexo no debe estar vacio.")]
        [Display(Name = "Sexo")]
        public SexoModel Sexo { get; set; }

        [Required(ErrorMessage = "Campo fecha de nacimiento no debe estar vacio.")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime?  FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Campo correo no debe estar vacio.")]
        [Display(Name = "Correo")]
        public List<CorreoModel> Correos { get; set; }

        [Required(ErrorMessage = "Campo Usuario no debe estar vacio.")]
        [Display(Name = "Usuario")]
        public UsuarioModel Usuario { get; set; }

        [Required(ErrorMessage = "Campodireccion no debe estar vacio.")]
        [Display(Name = "Direccion")]
        public List<DireccionModel> Direcciones { get; set; }

        [Required(ErrorMessage = "Campo telefeno no debe estar vacio.")]
        [Display(Name = "Telefono")]
        public List<TelefonoModel> Telefonos { get; set; }

        [Display(Name = "Borrado")]
        public bool Borrado { get; set; }
    }
}
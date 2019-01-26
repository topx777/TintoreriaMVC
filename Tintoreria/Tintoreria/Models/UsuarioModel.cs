using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class UsuarioModel
    {
        #region Atributos

        public int IdUsuario { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resource.Resource.EmptyField), ErrorMessageResourceType = typeof(Resource.Resource))]
        [Display(Name = "Username", ResourceType = typeof(Resource.Resource))]
        public string Username { get; set; }

        [Required(ErrorMessageResourceName = nameof(Resource.Resource.EmptyField), ErrorMessageResourceType = typeof(Resource.Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resource.Resource))]
        public string Password { get; set; }

        public bool EsAdmin { get; set; }

        #endregion

    }
}
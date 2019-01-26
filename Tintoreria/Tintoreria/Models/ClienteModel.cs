using System;
using System.Collections.Generic;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class ClienteModel
    {
        #region Proppiedades

        public int IdPersona { get; set; }

        public string Ci { get; set; }

        public string Nit { get; set; }

        public string Razon { get; set; }

        public DateTime FechaRegistro { get; set; }



        #endregion
    }
}
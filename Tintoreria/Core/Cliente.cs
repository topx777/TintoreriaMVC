using System;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class Cliente : Persona
    {
        #region Atributos

        public int Nit { get; set; }
        public string Razon { get; set; }
        public DateTime FechaRegistro { get; set; }

        #endregion
    }
}

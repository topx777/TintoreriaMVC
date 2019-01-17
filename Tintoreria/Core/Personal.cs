using System;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class Personal : Persona
    {
        #region Atributos

        public string CodPersonal { get; set; }
        public string Ci { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Cargo { get; set; }
        public double Sueldo { get; set; }
        public string Turno { get; set; }

        #endregion
    }
}

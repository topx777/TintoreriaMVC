using System;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class Personal : Persona
    {
        #region Atributos

        public string CodPersonal { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Cargo Cargo { get; set; }
        public decimal Sueldo { get; set; }

        #endregion
    } 
}

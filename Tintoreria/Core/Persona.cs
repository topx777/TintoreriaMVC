using System.Collections.Generic;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class Persona
    {
        #region Atributos

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public int SegundoApellido { get; set; }
        public int Sexo { get; set; }
        public int FechaNacimiento { get; set; }
        public int Correo { get; set; }
        public Usuario Usuario { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public List<Telefono> Telefonos { get; set; }

        #endregion

    }
}

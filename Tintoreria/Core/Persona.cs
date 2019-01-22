using System;
using System.Collections.Generic;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class Persona
    {
        #region Atributos

        public int IdPersona { get; set; }
        public string Ci { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public List<Correo> Correos  { get; set; }
        public Usuario Usuario { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public List<Telefono> Telefonos { get; set; }
        public bool Borrado { get; set; }

        #endregion

    }
}

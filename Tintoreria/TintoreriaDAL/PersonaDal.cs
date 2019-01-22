using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class PersonaDal
    {

        /// <summary>
        /// Inserta nuevo Persona a la base  de datos
        /// </summary>
        /// <param name="persona"></param>
        public static void Insertar(Persona persona)
        {
            //Methods.GenerateLogsDebug("PacienteDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un paciente"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"INSERT INTO Persona(Nombre, PrimerApellido, SegundoApellido, Sexo, FechaNacimiento, Correo, Usuario)
                                  VALUES(@nombre, @primerApellido, @segundoApellido, @sexo, @fechaNacimiento, @correo, @usuario)";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombre", persona.Nombre);
                command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
                command.Parameters.AddWithValue("@sexo", persona.Sexo);
                command.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@usuario", persona.Usuario.IdUsuario);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                //Methods.GenerateLogsRelease("PacienteDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Methods.GenerateLogsRelease("PacienteDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            //Methods.GenerateLogsDebug("PacienteDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un paciente"));

        }
    }
}

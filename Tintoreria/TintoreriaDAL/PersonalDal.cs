using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class PersonalDal
    {
        public static void Insertar(Personal personal, List<Telefono> telefonos, List<Direccion> direcciones)
        {
            Methods.GenerateLogsDebug("PersonalaDal", "InsertarPersonal", string.Format("{0} Info: {1}", 
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un personal"));

            SqlCommand command = null;

            //Consulta para insertar datos de personal
            string queryString = @"INSERT INTO Personal(IdPersona, CodPersonal, Ci, FechaIngreso, Cargo, Sueldo, Turno) 
                               VALUES (@idPersona ,@codPersonal, @ci, @fechaIngreso, @cargo, @sueldo, @turno)";
            try
            {
                UsuarioDal.Insertar(personal.Usuario);
                
                personal.Usuario.IdUsuario = Methods.GetActIDTable("Usuario");

                Persona persona = personal;
                PersonaDal.Insertar(persona);

                personal.IdPersona = Methods.GetActIDTable("Persona");

                //Insertar telefonos
                foreach(Telefono telf in telefonos)
                {
                    TelefonoDal.Insertar(telf, personal.IdPersona);
                }

                //Insertar direcciones
                foreach(Direccion direc in direcciones)
                {
                    DireccionDal.Insertar(direc, personal.IdPersona);
                }

                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idPersona", personal.IdPersona);
                command.Parameters.AddWithValue("@codPersonal", personal.CodPersonal);
                command.Parameters.AddWithValue("@ci", personal.Ci);
                command.Parameters.AddWithValue("@fechaIngreso", personal.FechaIngreso);
                command.Parameters.AddWithValue("@fechaIngreso", personal.Cargo);
                command.Parameters.AddWithValue("@sueldo", personal.Sueldo);
                command.Parameters.AddWithValue("@turno", personal.Turno);
                Methods.ExecuteBasicCommand(command);
                
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "InsertarPersonal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "InsertarPersonal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("PersonalDal", "InsertarPersonal", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un personal"));
        }

        //Eliminado logico de Personal
        public static void Eliminar (int id)
        {
            //Methods.GenerateLogsDebug("PersonalDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un personal"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "UPDATE Persona SET Borrado = 1 WHERE IdPersona=@id";

            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                //Methods.GenerateLogsRelease("PersonalDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Methods.GenerateLogsRelease("PersonalDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            //Methods.GenerateLogsDebug("PersonalDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un paciente"));
        }
    }
}

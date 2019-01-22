using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    class CorreoDal
    {
        /// <summary>
        /// Método para agregar un nuevo correo a la BD.
        /// </summary>
        /// <param name="correo">Objeto Correo</param>
        /// <param name="idPersona">Id de Persona</param>
        public static void Insertar(Correo correo, int idPersona)
        {
            Methods.GenerateLogsDebug("CorreoDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un correo"));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO Correo(idCorreo, Nombre, Principal, idPersona) VALUES(@idCorreo, @nombre, @principal, @idPersona)";
        
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idCorreo", correo.IdCorreo);
                command.Parameters.AddWithValue("@nombre", correo.Nombre);
                command.Parameters.AddWithValue("@principal", correo.Principal);
                command.Parameters.AddWithValue("@idPersona", idPersona);
                Methods.ExecuteBasicCommand(command);

            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CorreoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CorreoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("CorreoDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar correo"));
        }

        /// <summary>
        /// Actualiza los datos del correo en la base de datos
        /// </summary>
        /// <param name="correo"></param>
        public static void Actualizar(Correo correo)
        {
            Methods.GenerateLogsDebug("CorreoDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un correo"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Correo SET 
                                Nombre=@nombre, 
                                Principal=@principal 
                                WHERE IdPersona=@idCorreo";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombre", correo.Nombre);
                command.Parameters.AddWithValue("@principal", correo.Principal);
                command.Parameters.AddWithValue("@idCorreo", correo.IdCorreo);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CorreoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CorreoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("CorreoDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un correo"));

        }


        /// <summary>
        /// Eliminar Correo de la BD
        /// </summary>
        /// <param name="id"></param>
        //Eliminado logico de Persona
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("CorreoDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un correo"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "DELETE Correo WHERE IdPersona=@id";

            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CorreoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CorreoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            Methods.GenerateLogsDebug("CorreoDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para eliminar un correo"));
        }


        /// <summary>
        /// Obtiene  la informacion de un correo
        /// </summary>
        /// <param name="id">identificador de persona </param>
        /// <returns></returns>
        public static Correo Get(int id)
        {
            Correo res = new Correo();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "SELECT * FROM Correo WHERE IdCorreo = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Correo()
                    {
                        IdCorreo = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Principal = dr.GetBoolean(2)
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CorreoDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }


    }
}

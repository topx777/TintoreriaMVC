using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class TelefonoDal
    {
        /// <summary>
        /// Inserta un telefono a la base de datos 
        /// </summary>
        /// <param name="telefono"></param>
        /// <param name="idPersona"></param>
        public static void Insertar(Telefono telefono, int idPersona)
        {
            Methods.GenerateLogsDebug("TelefonoDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un telefono"));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO Telefono(Numero, Tipo, idPersona) VALUES(@numero, @tipo, @idPersona)";
        
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@numero", telefono.Numero);
                command.Parameters.AddWithValue("@tipo", telefono.Tipo.IdTipo);
                command.Parameters.AddWithValue("@idPersona", idPersona);
                Methods.ExecuteBasicCommand(command);

            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TelefonoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TelefonoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("TelefonoDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar telefono"));
        }


        /// <summary>
        /// Elimina telefono de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("TelefonoDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "DELETE FROM Telefono WHERE IdTelefono=@id";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("ClienteDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

        }

        /// <summary>
        /// Actualiza un Telefono de la base de datos
        /// </summary>
        /// <param name="telefono"></param>
        public static void Actualizar(Telefono telefono)
        {
            Methods.GenerateLogsDebug("TelefonoDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un Telefono"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Telefono SET Numero=@numero, Tipo=@tipo
                                    WHERE IdTelefono=@idTelefono";
            try
            {

                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@numero", telefono.Numero);
                command.Parameters.AddWithValue("@tipo", telefono.Tipo.IdTipo);
                command.Parameters.AddWithValue("@idTelefono", telefono.IdTelefono);

                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TelefonoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TelefonoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("TelefonoDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un Telefono"));

        }

        /// <summary>
        /// Obtiene un Telefono de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Telefono Get(int id)
        {
            Telefono res = new Telefono();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Telefono WHERE IdTelefono=@id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Telefono()
                    {
                        IdTelefono=dr.GetInt32(0),
                        Numero=dr.GetString(1),
                        Tipo=TipoDal.Get(dr.GetInt32(2)),
                        
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TelefonoDal", "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

        /// <summary>
        /// Obtiene una lista de Telefonos por id de Persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Telefono> GetList(int id)
        {
            List<Telefono> res = new List<Telefono>();

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Telefono WHERE IdPersona=@idPersona";

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idPersona", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new Telefono()
                    {
                        IdTelefono = dr.GetInt32(0),
                        Numero = dr.GetString(1),
                        Tipo = TipoDal.Get(dr.GetInt32(2))
                    });
                }

            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TelefonoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TelefonoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
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

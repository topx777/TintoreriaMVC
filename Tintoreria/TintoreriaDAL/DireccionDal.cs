using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class DireccionDal
    {
        /// <summary>
        /// Inserta una direccion a una persona
        /// </summary>
        /// <param name="direccion"></param>
        /// <param name="idPersona"></param>
        public static void Insertar(Direccion direccion, int idPersona)
        {
            Methods.GenerateLogsDebug("DireccionDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear una direccion"));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO Direccion(Descripcion, Tipo, Latitud, Longitud, idPersona) VALUES(@desc, @tipo, @latitud, @longitud, @idPersona)";

            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@desc", direccion.Descripcion);
                command.Parameters.AddWithValue("@tipo", direccion.Tipo.IdTipo);
                command.Parameters.AddWithValue("@latitud", direccion.Latitud);
                command.Parameters.AddWithValue("@longitud", direccion.Longitud);
                command.Parameters.AddWithValue("@idPersona", idPersona);
                Methods.ExecuteBasicCommand(command);

            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("DireccionDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar una direccion"));
        }

        /// <summary>
        /// Elimina Direccion ya existente
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("DireccionDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar una direccion"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "DELETE FROM Telefono WHERE IdDireccion=@id";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("DireccionDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un direccion"));

        }

        /// <summary>
        /// Actualiza un Direccion de la base de datos
        /// </summary>
        /// <param name="direccion"></param>
        public static void Actualizar(Direccion direccion)
        {
            Methods.GenerateLogsDebug("DireccionDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un Direccion"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Direccion SET Descripcion=@descripcion, Tipo=@tipo, Latitud=@latitud, Longitud=@longitud
                                    WHERE IdDireccion=@idDireccion";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@descripcion", direccion.Descripcion);
                command.Parameters.AddWithValue("@tipo", direccion.Tipo.IdTipo);
                command.Parameters.AddWithValue("@latitud", direccion.Latitud);
                command.Parameters.AddWithValue("@longitud", direccion.Longitud);
                command.Parameters.AddWithValue("@idDireccion", direccion.IdDireccion);

                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("DireccionDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar una Direccion"));

        }

        /// <summary>
        /// Obtiene un Direccion de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Direccion Get(int id)
        {
            Direccion res = new Direccion();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "Select * From Direccion where IdDireccion = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Direccion()
                    {
                        IdDireccion = dr.GetInt32(0),
                        Descripcion=dr.GetString(1),
                        Tipo=TipoDal.Get(dr.GetInt32(2)),
                        Latitud=dr.GetDouble(3),
                        Longitud=dr.GetDouble(4),
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

        /// <summary>
        /// Obtiene una lista de direcciones por id de Persona
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Direccion> GetList(int id)
        {
            List<Direccion> res = new List<Direccion>();

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Direccion WHERE IdPersona=@idPersona";

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idPersona", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new Direccion()
                    {
                        IdDireccion = dr.GetInt32(0),
                        Descripcion = dr.GetString(1),
                        Tipo = TipoDal.Get(dr.GetInt32(2)),
                        Latitud = dr.GetSqlDecimal(3).ToDouble(),
                        Longitud = dr.GetSqlDecimal(4).ToDouble()
                    });
                }

            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
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

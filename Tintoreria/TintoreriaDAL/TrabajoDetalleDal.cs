using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class TrabajoDetalleDal
    {
        /// <summary>
        /// Inserta nuevo trabajo detalle
        /// </summary>
        /// <param name="trabajoDetalle">Objeto TrabajoDetalle</param>
        /// <param name="idTrabajo">Identificador de Trabajo</param>
        public static void Insertar(TrabajoDetalle trabajoDetalle, int idTrabajo)
        {
            Methods.GenerateLogsDebug("TrabajoDetalleDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para insertar un Trabajo Detalle"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"INSERT INTO TrabajoDetalle(CodigoPrenda, Trabajo, Categoria, PrecioFinal, Peso, Estado)
                                    VALUES
                                   (@codigoPrenda, @idTrabajo, @categoria, @precioFinal, @peso, @estado)";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@codigoPrenda", trabajoDetalle.CodigoPrenda);
                command.Parameters.AddWithValue("@idTrabajo", idTrabajo);
                command.Parameters.AddWithValue("@categoria", trabajoDetalle.Categoria.IdCategoria);
                command.Parameters.AddWithValue("@precioFinal", trabajoDetalle.PrecioFinal);
                command.Parameters.AddWithValue("@peso", trabajoDetalle.Peso);
                command.Parameters.AddWithValue("@estado", trabajoDetalle.Estado.IdEstado);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("TrabajoDetalleDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un trabajoDetalle"));
        }

        /// <summary>
        /// Elimina trabajo Detalle ya existente
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("TrabajoDetalleDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Trabajo Detalle"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "UPDATE TrabajoDetalle SET Borrado = 1 WHERE IdTrabajoDetalle=@id";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("TrabajoDetalleDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un trabajo detalle"));

        }

        /// <summary>
        /// Actualiza un trabajo detalle de la base de datos
        /// </summary>
        /// <param name="trabajoDetalle"></param>
        public static void Actualizar(TrabajoDetalle trabajoDetalle)
        {
            Methods.GenerateLogsDebug("TrabajoDetalleDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un Trabajo"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE TrabajoDetalle SET 
                                    CodigoPrenda=@codigoPrenda, 
                                    Categoria=@categoria, 
                                    PrecioFinal=@precioFinal, 
                                    Peso=@peso, 
                                    Estado=@estado, 
                                    WHERE IdTrabajoDetalle=@idTrabajoDetalle";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@codigoPrenda", trabajoDetalle.CodigoPrenda);
                command.Parameters.AddWithValue("@categoria", trabajoDetalle.Categoria.IdCategoria);
                command.Parameters.AddWithValue("@precioFinal", trabajoDetalle.PrecioFinal);
                command.Parameters.AddWithValue("@peso", trabajoDetalle.Peso);
                command.Parameters.AddWithValue("@estado", trabajoDetalle.Estado.IdEstado);
                command.Parameters.AddWithValue("@idTrabajoDetalle", trabajoDetalle.IdTrabajoDetalle);

                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("TrabajoDetalleDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un Trabajo Detalle"));

        }

        /// <summary>
        /// Obtiene un Trabajo detalle de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static TrabajoDetalle Get(int id)
        {
            TrabajoDetalle res = new TrabajoDetalle();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "SELECT * FROM TrabajoDetalle WHERE IdTrabajo = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new TrabajoDetalle()
                    {
                        IdTrabajoDetalle = dr.GetInt32(0),
                        CodigoPrenda = dr.GetString(1),
                        Categoria = CategoriaDal.Get(dr.GetInt32(3)),
                        PrecioFinal = dr.GetSqlDecimal(4).ToDouble(),
                        Peso = dr.GetSqlDecimal(5).ToDouble(),
                        Estado = EstadoDal.Get(dr.GetInt32(6)),
                        Borrado = dr.GetBoolean(7)
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalle", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }


        /// <summary>
        /// Obtiene Lista de Trabajo Detalle de un Trabajo especifico
        /// </summary>
        /// <param name="id">Identificador de Trabajo</param>
        /// <returns>Lista de Objetos Personal</returns>
        public static List<TrabajoDetalle> GetList(int id)
        {
            List<TrabajoDetalle> res = new List<TrabajoDetalle>();

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM TrabajoDetalle WHERE Borrado = 0 AND Trabajo = @idTrabajo";

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@idTrabajo", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new TrabajoDetalle()
                    {
                        IdTrabajoDetalle = dr.GetInt32(0),
                        CodigoPrenda = dr.GetString(1),
                        Categoria = CategoriaDal.Get(dr.GetInt32(3)),
                        PrecioFinal = dr.GetSqlDecimal(4).ToDouble(),
                        Peso = dr.GetSqlDecimal(5).ToDouble(),
                        Estado = EstadoDal.Get(dr.GetInt32(6)),
                        Borrado = dr.GetBoolean(7)
                    });
                }
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
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

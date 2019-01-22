using System;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    /// <summary>
    /// Clase que permite interactuar con la Base de Datos de Trabajo
    /// </summary>
    public class TrabajoDal
    {
        /// <summary>
        /// Inserta nuevo trabajo
        /// </summary>
        /// <param name="trabajo"></param>
        public static void Insertar(Trabajo trabajo)
        {
            Methods.GenerateLogsDebug("TrabajoDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Trabajo"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"INSERT INTO Trabajo(Cliente, FechaTrabajo, TotalPrecio, FechaEntrega, PedidoDistancia, EntregaDomicilio, TrabajoDetalle)
                                    VALUES
                                   (@Cliente, @FechaTrabajo, @TotalPrecio, @FechaEntrega, @PedidoDistancia, @EntregaDomicilio, @TrabajoDetalle)";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@Cliente", trabajo.Cliente.IdPersona);
                command.Parameters.AddWithValue("@FechaTrabajo", DateTime.Now);
                command.Parameters.AddWithValue("@TotalPrecio", trabajo.TotalPrecio);
                command.Parameters.AddWithValue("@FechaEntrega", trabajo.FechaEntrega);
                command.Parameters.AddWithValue("@PedidoDistancia", trabajo.PedidoDistancia.IdPedido);
                command.Parameters.AddWithValue("@EntregaDomicilio", trabajo.EntregaDomicilio);
                command.Parameters.AddWithValue("@TrabajoDetalle", trabajo.TrabajoDetalle);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

                Methods.GenerateLogsDebug("TrabajoDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un paciente"));

        }

        /// <summary>
        /// Elimina trabajo ya existente
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("TrabajoDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Trabajo"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "UPDATE Trabajo SET Eliminado = 1 WHERE IdTrabajo=@id";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

                Methods.GenerateLogsDebug("TrabajoDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un cliente"));

        }

        /// <summary>
        /// Actualiza un trabajo de la base de datos
        /// </summary>
        /// <param name="trabajo"></param>
        public static void Actualizar(Trabajo trabajo)
        {
            Methods.GenerateLogsDebug("TrabajoDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un Trabajo"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Trabajo SET Cliente=@cliente, 
                                    FechaTrabajo=@fechaTrabajo,
                                    TotalPrecio=@totalPrecio, 
                                    FechaEntrega=@fechaEntrega, 
                                    PedidoDistancia=@pedidoDistancia, 
                                    EntregaDomicilio=@entregaDomicilio, 
                                    Borrado=@borrado 
                                    Where IdTrabajo=@idTrabajo";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@cliente", trabajo.Cliente.IdPersona);
                command.Parameters.AddWithValue("@fechaTrabajo", trabajo.FechaTrabajo);
                command.Parameters.AddWithValue("@totalPrecio", trabajo.TotalPrecio);
                command.Parameters.AddWithValue("@fechaEntrega", trabajo.FechaEntrega);
                command.Parameters.AddWithValue("@pedidoDistancia", trabajo.PedidoDistancia);
                command.Parameters.AddWithValue("@entregaDomicilio", trabajo.EntregaDomicilio);
                command.Parameters.AddWithValue("@borrado", trabajo.Borrado);
                command.Parameters.AddWithValue("@idTrabajo", trabajo.IdTrabajo);

                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

                Methods.GenerateLogsDebug("TrabajoDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un Trabajo"));

        }

        /// <summary>
        /// Obtiene un Trabajo de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Trabajo Get(int id)
        {
            Trabajo res = new Trabajo();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "Select * From Trabajo where IdTrabajo = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Trabajo()
                    {
                        IdTrabajo=dr.GetInt32(0),
                        Cliente=ClienteDal.Get(dr.GetInt32(1)),
                        FechaTrabajo=dr.GetDateTime(2),
                        //PedidoDistancia=Pedido.Get(dr.GetInt32(3)),
                        EntregaDomicilio=dr.GetBoolean(4),
                        Borrado=dr.GetBoolean(5)
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PacienteDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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

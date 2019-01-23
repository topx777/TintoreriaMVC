using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class PedidoDal
    {

        /// <summary>
        /// Inserta nuevo Pedido a la base  de datos
        /// </summary>
        /// <param name="pedido"></param>
        public static void Insertar(Pedido pedido)
        {
            Methods.GenerateLogsDebug("PedidoDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para agregar un pedido."));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta
            string queryString = @"INSERT INTO Pedido(Recepcion, PrecioPedido, DireccionPedido)
                                  VALUES(@recepcion, @precioPedido, @direccionPedido)";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@recepcion", pedido.Recepcion);
                command.Parameters.AddWithValue("@precioPedido", pedido.PrecioPedido);
                command.Parameters.AddWithValue("@direccionPedido", pedido.);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PedidoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PedidoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("PedidoDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un pedido"));

        }

        /// <summary>
        /// Actualiza los datos del pedido en la base de datos
        /// </summary>
        /// <param name="pedido"></param>
        public static void Actualizar(Pedido pedido)
        {
            Methods.GenerateLogsDebug("PedidoDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un pedido"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Pedido SET 
                                    Recepcion=@recepcion, PrecioPedido=@precioPedido, 
                                    WHERE IdPedido=@idPedido";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@recepcion", pedido.Recepcion);
                command.Parameters.AddWithValue("@precioPedido", pedido.PrecioPedido);
                command.Parameters.AddWithValue("@idPedido", pedido.IdPedido);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PedidoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PedidoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("PedidoDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un pedido"));

        }


        /// <summary>
        /// Eliminar Pedido de la BD
        /// </summary>
        /// <param name="id"></param>
        //Eliminado logico de Persona
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("PedidoDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un pedido"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "DELETE Pedido WHERE IdPedido=@id";

            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PedidoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PedidoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            Methods.GenerateLogsDebug("PedidoDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para eliminar un pedido"));
        }


        /// <summary>
        /// Obtiene  la informacion de un pedido
        /// </summary>
        /// <param name="id">identificador de pedido</param>
        /// <returns></returns>
        public static Pedido Get(int id)
        {
            Pedido res = new Pedido();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "SELECT * FROM Pedido WHERE IdPedido = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Pedido()
                    {
                        IdPedido = dr.GetInt32(0),
                        Recepcion = dr.GetString(1),
                        PrecioPedido = dr.GetSqlDecimal(2).ToDouble(),
                        DireccionPedido = DireccionDal.Get(dr.GetInt32(3))
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PedidoDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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

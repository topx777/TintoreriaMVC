using System;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class TrabajoBrl
    {
        /// <summary>
        /// Insertar Nuevo Trabajo en la BD
        /// </summary>
        /// <param name="trabajo">Objeto de tipo Trabajo</param>
        public static void Insertar(Trabajo trabajo)
        {
            try
            {
                trabajo.Cliente = ClienteBrl.GetCI(trabajo.Cliente.Ci);
                trabajo.FechaTrabajo = DateTime.Now;

                if(trabajo.EntregaDomicilio)
                {
                    PedidoDal.Insertar(trabajo.PedidoDistancia);
                    int idPedido = Methods.GetActIDTable("Pedido");
                    trabajo.PedidoDistancia.IdPedido = idPedido;
                    trabajo.TotalPrecio += trabajo.PedidoDistancia.PrecioPedido;
                }
                else
                {
                    trabajo.PedidoDistancia = null;
                }

                foreach(TrabajoDetalle x in trabajo.TrabajoDetalle)
                {
                    x.Categoria = CategoriaBrl.Get(x.Categoria.IdCategoria);
                    x.PrecioFinal = x.Categoria.Precio * Convert.ToDecimal(x.Peso);
                    trabajo.TotalPrecio += x.PrecioFinal;
                }

                TrabajoDal.Insertar(trabajo);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// metodo para eliminar un Trabajo
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            try
            {
                TrabajoDal.Eliminar(id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

        }

        /// <summary>
        /// Actualiza datos de Trabajo en la base de datos 
        /// </summary>
        /// <param name="trabajo"></param>
        public static void Actualizar(Trabajo trabajo)
        {
            try
            {
                TrabajoDal.Actualizar(trabajo);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }


        /// <summary>
        /// METODO PARA Obtener un trabajo basado en el id
        /// </summary>
        /// <param name="id">Identificador Trabajo</param>
        /// <returns></returns>
        public static Trabajo Get(int id)
        {
            Trabajo trabajo = null;
            try
            {
                trabajo = TrabajoDal.Get(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return trabajo;
        }

        /// <summary>
        /// Metodo para obtener la cantidad total de registros de la BD
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            int cant = 0;
            try
            {
                cant = TrabajoDal.Count();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cant;
        }

    }
}

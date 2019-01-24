using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    class ClienteBrl
    {
        /// <summary>
        /// Metodo para Insertar un Cliente
        /// </summary>
        /// <param name="cliente"></param>
        public static void Insertar(Cliente cliente)
        {
            try
            {
                ClienteDal.Insertar(cliente);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para Obtener un  Cliente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Cliente Get(int id)
        {
            Cliente cliente = null;
            try
            {
                cliente = ClienteDal.Get(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cliente;
        }

        /// <summary>
        /// actualiza un Cliente
        /// </summary>
        /// <param name="cliente"></param>
        public static void Actualizar(Cliente cliente)
        {
            try
            {
                ClienteDal.Actualizar(cliente);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("clienteDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para eliminar logicamente un Cliente
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            try
            {
                ClienteDal.Eliminar(id);
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

        }

        public static List<Cliente> ListCliente()
        {
            List < Cliente > clientes= null;
            try
            {
                clientes=ClienteDal.GetList();
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("ClienteBrl", "ListCliente",
                string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(),
                DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("ClienteBrl", "ListCliente", string.Format("{0} {1} Error: {2}",
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            return clientes;

        }
    }
}

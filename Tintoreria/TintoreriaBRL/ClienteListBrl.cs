using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class ClienteListBrl
    {
        /// <summary>
        /// Obtiene la lista de Clientes
        /// </summary>
        /// <returns>Cliente Lista</returns>
        public static ClienteList Get(int page, int pageSize)
        {
            ClienteList lista = null;

            try
            {
                lista = ClienteListDal.Get(page, pageSize);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        /// <summary>
        /// Obtiene la lista de Cliente
        /// </summary>
        /// <returns>Cliente Lista</returns>
        public static ClienteList Get()
        {
            ClienteList lista = null;

            try
            {
                lista = ClienteListDal.Get();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }

        /// <summary>
        /// Obtener Cantidad de Registros de la bd
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            int count = 0;

            try
            {
                count = ClienteListDal.Count();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return count;
        }
    }
}

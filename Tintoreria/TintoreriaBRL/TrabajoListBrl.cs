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
    public class TrabajoListBrl
    {
        /// <summary>
        /// obtiene lista de cargos
        /// </summary>
        /// <returns></returns>
        public static TrabajoList Get(int page, int pageSize)
        {
            TrabajoList lista = null;

            try
            {
                //lista = TrabajoDal.GetList(offset, next);
                lista = TrabajoDal.GetLista(page, pageSize);
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
                count = TrabajoDal.Count();

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

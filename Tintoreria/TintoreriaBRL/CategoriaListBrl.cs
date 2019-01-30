using System;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class CategoriaListBrl
    {
        /// <summary>
        /// Obtiene la lista de categorias
        /// </summary>
        /// <returns>Categoria Lista</returns>
        public static CategoriaList Get(int page, int pageSize)
        {
            CategoriaList lista = null;

            try
            {
                lista = CategoriaListDal.Get(page, pageSize);

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
                count = CategoriaListDal.Count();

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

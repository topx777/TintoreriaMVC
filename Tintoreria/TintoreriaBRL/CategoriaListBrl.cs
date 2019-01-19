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
        public static CategoriaList Get()
        {
            CategoriaList lista = null;

            try
            {
                lista = CategoriaListDal.Get();
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

    }
}

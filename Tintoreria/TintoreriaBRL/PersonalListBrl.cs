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
    class PersonalListBrl
    {
        /// <summary>
        /// Obtiene la lista de personal
        /// </summary>
        /// <returns>Categoria Lista</returns>
        public static PersonalList Get()
        {
            PersonalList lista = null;

            try
            {
                lista = PersonalListDal.Get();

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

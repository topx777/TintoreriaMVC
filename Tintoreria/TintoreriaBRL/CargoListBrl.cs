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
    public class CargoListBrl
    {
        /// <summary>
        /// obtiene lista de cargos
        /// </summary>
        /// <returns></returns>
        public static CargoList Get()
        {
            CargoList lista = null;

            try
            {
                lista = CargoListDal.Get();

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

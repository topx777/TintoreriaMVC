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
    public class SexoBrl
    {
        public static Sexo Get(int id)
        {
           Sexo sexo = null;
            try
            {
                sexo = SexoDal.Get(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sexo;
        }
    }
}

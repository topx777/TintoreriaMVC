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
    public class TipoBrl
    {
        public static Tipo Get(int id)
        {
            Tipo tipo = null;
            try
            {
                tipo = TipoDal.Get(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return tipo;
        }

        public static List<Tipo> Get()
        {
            List<Tipo> tipoLIst = null;
            try
            {
                tipoLIst = TipoDal.GetList();
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TipoBrl", "ListTipo",
                string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(),
                DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TipoBrl", "LisTipo", string.Format("{0} {1} Error: {2}",
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            return tipoLIst;
        }
    }
}

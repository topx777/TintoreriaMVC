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
    class PersonalBrl
    {
        public static void InsertarPersonal(Personal personal, List<Telefono> telefonos, List<Direccion> direcciones)
        {
            try
            {
                PersonalDal.Insertar(personal, telefonos, direcciones);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PersonalBrl", "InsertarPersonal",
                string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(),
                DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonalBrl", "InsertarPersonal", string.Format("{0} {1} Error: {2}", 
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
         
        }
    }
}

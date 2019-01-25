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
    public class PersonalBrl
    {
        /// <summary>
        /// Inserta un nuevo Personal a la BD
        /// </summary>
        /// <param name="personal"></param>
        public static void Insertar(Personal personal)
        {
            try
            {
                PersonalDal.Insertar(personal);
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


        /// <summary>
        /// METODO PARA Obtener un personal basado en el id
        /// </summary>
        /// <param name="id">Identificador Personal</param>
        /// <returns></returns>
        public static Personal Get(int id)
        {
            Personal personal = null;
            try
            {
                personal = PersonalDal.Get(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return personal;
        }

    }
}

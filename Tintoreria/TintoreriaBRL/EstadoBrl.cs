using System;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using System.Data.SqlClient;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class EstadoBrl
    {

        /// <summary>
        /// Metodo Para Obtener una categoria basado en el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Estado Get(int id)
        {
            Estado estado = null;
            try
            {
                estado = EstadoDal.Get(id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("EsatdoBrl", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("EstadoBrl", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            return estado;
        }

    }
}

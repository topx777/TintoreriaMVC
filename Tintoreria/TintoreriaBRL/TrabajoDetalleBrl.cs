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
    public class TrabajoDetalleBrl
    {

        /// <summary>
        /// Insertar Nuevo Trabajo en la BD
        /// </summary>
        /// <param name="trabajo">Objeto de tipo Trabajo</param>
        public static void Insertar(TrabajoDetalle trabajoDetalle, int idTrabajo)
        {
            try
            {
                TrabajoDetalleDal.Insertar(trabajoDetalle, idTrabajo);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDetalleBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }


    }
}

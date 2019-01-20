using System;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    class TrabajoBrl
    {
        public static void Insertar(Trabajo trabajo)
        {
            try
            {
                TrabajoDal.Insertar(trabajo);
            }
            catch (SqlException ex)
            {
                //Methods.GenerateLogsRelease("PacienteBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Methods.GenerateLogsRelease("PacienteBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

    }
}

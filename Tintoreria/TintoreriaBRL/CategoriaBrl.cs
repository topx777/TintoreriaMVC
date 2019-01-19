using System;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class CategoriaBrl
    {
        /// <summary>
        /// Metodo que sirve para insertar a la base de datos
        /// </summary>
        /// <param name="categoria">Objeto paciente</param>
        public static void Insertar(Categoria categoria)
        {
            try
            {
                CategoriaDal.Insertar(categoria);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PacienteBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PacienteBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

    }
}

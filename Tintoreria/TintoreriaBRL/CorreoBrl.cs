using System;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class CorreoBrl
    {
        /// <summary>
        /// Metodo para insertar correos
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="id"></param>
        public static void Insertar(Correo correo, int id)
        {
            try
            {
                CorreoDal.Insertar(correo, id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CorreoBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CorreoBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Metodo para obtener correo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Correo Get(int id)
        {
            Correo correo = null;
            try
            {
                correo = CorreoDal.Get(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return correo;
        }

        /// <summary>
        /// Metodo para actuyalizar un correo
        /// </summary>
        /// <param name="correo"></param>
        public static void Actualizar(Correo correo)
        {
            try
            {
                CorreoDal.Actualizar(correo);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CorreoBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CorreoBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }
        
        public static void Eliminar(int id)
        {
            try
            {
                CorreoDal.Eliminar(id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CorreoBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CorreoBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }
    }
}

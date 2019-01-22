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

        /// <summary>
        /// METODO PARA Obtener una categoria basado en el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Categoria Get(int id)
        {
            Categoria categoria = null;
            try
            {
                categoria = CategoriaDal.Get(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return categoria;
        }

        /// <summary>
        /// Actualiza los datos de la categoria en la base de datos
        /// </summary>
        /// <param name="categoria"></param>
        public static void Actualizar(Categoria categoria)
        {
            try
            {
                CategoriaDal.Actualizar(categoria);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Eliminar Categoria
        /// </summary>
        /// <param name="id">Identificador del Categoria</param>
        public static void Eliminar(int id)
        {
            try
            {
                CategoriaDal.Eliminar(id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CategoriaBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CategoriaBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }






        }
    }

}
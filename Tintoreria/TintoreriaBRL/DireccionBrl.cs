using System;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class DireccionBrl
    {
        /// <summary>
        /// Metodo que sirve para insertar a la base de datos
        /// </summary>
        /// <param name="direccion">Objeto paciente</param>
        public static void Insertar(Direccion direccion, int idPersona)
        {
            try
            {
                DireccionDal.Insertar(direccion, idPersona);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Metodo Para Obtener una categoria basado en el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Direccion Get(int id)
        {
            Direccion direccion = null;
            try
            {
                direccion = DireccionDal.Get(id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionBrl", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionBrl", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            return direccion;
        }

        /// <summary>
        /// Actualiza los datos de una direccion en la base de datos
        /// </summary>
        /// <param name="direccion"></param>
        public static void Actualizar(Direccion direccion)
        {
            try
            {
                DireccionDal.Actualizar(direccion);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Eliminar Direccion
        /// </summary>
        /// <param name="id">Identificador del Categoria</param>
        public static void Eliminar(int id)
        {
            try
            {
                DireccionDal.Eliminar(id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CategoriaBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene una lista a partir de un id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List Direcciones</returns>
        public static List<Direccion> GetList(int id)
        {
            List<Direccion> lista = new List<Direccion>();
            try
            {
                lista= DireccionDal.GetList(id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionBrl", "getList", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "getList", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            return lista;
        }
    }
}

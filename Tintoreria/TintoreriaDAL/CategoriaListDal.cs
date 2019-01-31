using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class CategoriaListDal
    {

        /// <summary>
        /// Obtiene la cantidad total de registros de la BD
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            SqlCommand cmd = null;

            int count = 0;

            string queryString = "SELECT COUNT(*) FROM Categoria";

            try
            {
                cmd = new SqlCommand(queryString);
                cmd.Connection = Methods.ObtenerConexion();
                cmd.Connection.Open();

                Object x = cmd.ExecuteScalar();
                count = Convert.ToInt32(x);
            }
            catch (SqlException ex)
            {
                //Methods.GenerateLogsRelease("TrabajoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Methods.GenerateLogsRelease("TrabajoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            //Methods.GenerateLogsDebug("TrabajoDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un trabajo"));

            return count;
        }

        /// <summary>
        /// Obtener Lista de Categorias
        /// </summary>
        /// <returns></returns>
        public static CategoriaList Get()
        {
            CategoriaList res = new CategoriaList();

            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string query = @"SELECT * FROM Categoria";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new Categoria()
                    {
                        IdCategoria = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Descripcion = dr.GetString(2),
                        Precio = dr.GetDecimal(3)
                    });
                }

            }
            catch (SqlException ex)
            {
                //Methods.GenerateLogsRelease("KeyValuePacienteListDal", "Obtener", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                //Methods.GenerateLogsRelease("KeyValuePacienteListDal", "Obtener", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

        /// <summary>
        /// Obtener Lista de Categorias
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static CategoriaList Get(int page, int pageSize)
        {
            CategoriaList res = new CategoriaList();

            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string query = @"SELECT * FROM Categoria ORDER BY Nombre ASC 
                        OFFSET @pageSize * (@page - 1) ROWS FETCH NEXT @pageSize ROWS ONLY";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new Categoria()
                    {
                        IdCategoria = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Descripcion = dr.GetString(2),
                        Precio = dr.GetDecimal(3)
                    });
                }

            }
            catch (SqlException ex)
            {
                //Methods.GenerateLogsRelease("KeyValuePacienteListDal", "Obtener", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                //Methods.GenerateLogsRelease("KeyValuePacienteListDal", "Obtener", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

    }
}

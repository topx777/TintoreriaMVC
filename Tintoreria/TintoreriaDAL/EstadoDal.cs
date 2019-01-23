using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class EstadoDal
    {
        /// <summary>
        /// Get Estado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Estado Get(int id)
        {
            Estado res = new Estado();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Estado WHERE IdEstado=@id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Estado()
                    {
                        IdEstado = dr.GetInt32(0),
                        Nombre = dr.GetString(1)
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("EstadoDal", "Obtener(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

        /// <summary>
        /// Obtiene Lista de Estados
        /// </summary>
        /// <returns>Lista de Objetos Estado</returns>
        public static List<Estado> GetList()
        {
            List<Estado> res = new List<Estado>();

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Estado";

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new Estado()
                    {
                        IdEstado = dr.GetInt32(0),
                        Nombre = dr.GetString(1)
                    });
                }

            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("EstadoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("EstadoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
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

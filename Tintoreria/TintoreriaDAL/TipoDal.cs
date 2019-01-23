using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    class TipoDal
    {

        /// <summary>
        /// Obtiene un Direccion de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Tipo Get(int id)
        {
            Tipo res = new Tipo();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "Select * From Tipo  WHERE  IdTipo = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Tipo()
                    {
                        IdTipo  = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TipoDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }

        /// <summary>
        /// Obtiene Lista de Tipos
        /// </summary>
        /// <returns>Lista de Objetos Tipo</returns>
        public static List<Tipo> GetList()
        {
            List<Tipo> res = new List<Tipo>();

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Tipo";

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new Tipo()
                    {
                        IdTipo = dr.GetInt32(0),
                        Nombre = dr.GetString(1)
                    });
                }

            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TipoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TipoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
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

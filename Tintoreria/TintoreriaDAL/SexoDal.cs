using System;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    class SexoDal
    {
        /// <summary>
        /// Get Sexo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Sexo Get(int id)
        {
            Sexo res = new Sexo();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Sexo WHERE IdSexo=@id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Sexo()
                    {
                        IdSexo=dr.GetInt32(0),
                        Nombre=dr.GetString(1)
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("SexoDal", "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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

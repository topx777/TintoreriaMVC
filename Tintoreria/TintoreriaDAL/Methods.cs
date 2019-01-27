using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public sealed class Methods
    {
        //Cadena de conexion a la base de datos
        public static string _connectionString = ConfigurationManager.ConnectionStrings["TintoreriaConnectionString"].ConnectionString;

        /// <summary>
        /// Retorna un comando sql relacionado a la conexion
        /// </summary>
        /// <returns></returns>
        public static SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            return cmd;
        }

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }





        /// <summary>
        /// Retorna un comando sql relacionado a la conexion
        /// </summary>
        /// <param name="query">consulta para ejecutar el comando</param>
        /// <returns></returns>
        public static SqlCommand CreateBasicCommand(string query)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Connection = connection;
            return cmd;
        }
        /// <summary>
        /// recibe un sql command y lo ejecuta con ExecuteNonQuery();  
        /// </summary>
        /// <param name="cmd"> comando relacionado con una conexion</param>
        public static void ExecuteBasicCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in ExecuteBasicCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in ExecuteBasicCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        /// <summary>
        /// realiza un conteo hasta 255
        /// </summary>
        /// <param name="cmd">comando a ejecutar COUNT</param>
        /// <returns>retornael valor del count</returns>
        public static byte ExecuteBasicCommandCount(SqlCommand cmd)
        {
            byte x;
            try
            {
                cmd.Connection.Open();
                x = (byte)cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in ExecuteBasicCommandCount", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in ExecuteBasicCommandCount", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return x;
        }
        /// <summary>
        /// recibe un sql command y consulta sql en caso de no usar el otro metodo
        /// </summary>
        /// <param name="cmd">sql command</param>
        /// <param name="query">consulta</param>
        public static void ExecuteBasicCommand(SqlCommand cmd, string query)
        {
            try
            {
                cmd.CommandText = query;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in ExecuteBasicCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in ExecuteBasicCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        /// <summary>
        /// recibe un comando lo ejecuta y retorna el resultado en un datatable
        /// </summary>
        /// <param name="cmd">sql command con consulta select</param>
        /// <returns>data table con resultado de un select</returns>
        public static DataTable ExcecuteDataTableCommand(SqlCommand cmd)
        {
            DataTable res = new DataTable();

            try
            {
                //  cmd.Connection.Open();
                SqlDataAdapter data = new SqlDataAdapter(cmd);//la conexion ya esta abierta
                data.Fill(res);

            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in ExcecuteDataTableCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in ExcecuteDataTableCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                // cmd.Connection.Close();
            }

            return res;
        }

        /// <summary>
        /// recibe un comando lo ejecuta y retorna el resultado en un datatable
        /// </summary>
        /// <param name="cmd">sql command con consulta select</param>
        /// <returns>data table con resultado de un select</returns>
        public static DataTable ExcecuteDataTableCommand()
        {
            DataTable res = new DataTable();

            try
            {
                //  cmd.Connection.Open();
                SqlDataAdapter data = new SqlDataAdapter();//la conexion ya esta abierta
                data.Fill(res);

            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in ExcecuteDataTableCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in ExcecuteDataTableCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                // cmd.Connection.Close();
            }


            return res;
        }

        /// <summary>
        /// devuelve un data reader
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteDataReaderCommand(SqlCommand cmd)
        {
            SqlDataReader res = null;
            try
            {
                cmd.Connection.Open();
                res = cmd.ExecuteReader();
            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in ExcecuteDataReaderCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in ExcecuteDataReaderCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// comand scalar
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string ExcecuteScalarCommand(SqlCommand cmd)
        {
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteScalar().ToString();
            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in ExcecuteScalarCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in ExcecuteScalarCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        /// <summary>
        /// consigue el siguiente id de una tabla aummentado con su incremento
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static int GetNextIDTable(string tabla)
        {
            int res = -1;
            string query = "SELECT IDENT_CURRENT('" + tabla + "')+ IDENT_INCR('" + tabla + "')";
            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = int.Parse(ExcecuteScalarCommand(cmd));
            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in GetNextIDTable", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in GetNextIDTable", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            return res;
        }
        /// <summary>
        /// consigue el ultimo id de una tabla
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public static int GetActIDTable(string tabla)
        {
            int res = -1;
            string query = "SELECT IDENT_CURRENT('" + tabla + "')";
            try
            {
                SqlCommand cmd = CreateBasicCommand(query);
                res = int.Parse(ExcecuteScalarCommand(cmd));
            }
            catch (SqlException ex)
            {
                GenerateLogsRelease("Methods", "SqlException in GetActIDTable", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                GenerateLogsRelease("Methods", "Exception in GetActIDTable", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            return res;
        }

        /// <summary>
        /// ejecuta n comandos en una transaccion
        /// </summary>
        /// <param name="cmds">lista de comandos a ejecutar</param>
        public static void ExecuteNBasicCommand(List<SqlCommand> cmds)
        {
            SqlTransaction tran = null;
            SqlCommand cmd1 = cmds[0];
            try
            {
                cmd1.Connection.Open();
                tran = cmd1.Connection.BeginTransaction();

                foreach (SqlCommand cmd in cmds)
                {
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (SqlException ex)
            {
                tran.Rollback();
                GenerateLogsRelease("Methods", "SqlException in ExecuteNBasicCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                GenerateLogsRelease("Methods", "Exception in ExecuteNBasicCommand", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                cmd1.Connection.Close();
            }
        }
        /// <summary>
        /// crea n comandos para ejecutarlos despues recibiendo una lista de consultas
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static List<SqlCommand> CreateNCommands(List<string> lista)
        {
            List<SqlCommand> res = new List<SqlCommand>();

            SqlConnection connection = new SqlConnection(_connectionString);
            for (int i = 0; i < lista.Count; i++)
            {
                SqlCommand cmd = new SqlCommand(lista[i]);
                cmd.Connection = connection;
                res.Add(cmd);
            }
            return res;
        }
        /// <summary>
        /// crea n comandos 
        /// </summary>
        /// <param name="x">cantidad de comandos a crear</param>
        /// <returns></returns>
        public static List<SqlCommand> CreateNCommands(int x)
        {
            List<SqlCommand> res = new List<SqlCommand>();

            SqlConnection connection = new SqlConnection(_connectionString);
            for (int i = 0; i < x; i++)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                res.Add(cmd);
            }
            return res;
        }

        public static void GenerateLogsDebug(string tabla, string titulo, string mensaje)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0} {1} {2}", mensaje, titulo, tabla));
        }

        public static void GenerateLogsRelease(string tabla, string titulo, string mensaje)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("{0} {1} {2}", mensaje, titulo, tabla));
        }
    }
}

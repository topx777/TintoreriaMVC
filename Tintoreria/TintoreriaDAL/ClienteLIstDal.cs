using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class ClienteListDal
    {

        /// <summary>
        /// Obtiene la cantidad total de registros de la BD
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            SqlCommand cmd = null;

            int count = 0;

            string queryString = "SELECT COUNT(*) FROM Cliente INNER JOIN Persona ON Cliente.IdPersona=Persona.IdPersona WHERE Persona.Borrado=0";

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
        /// Obtener Lista de Clientes
        /// </summary>
        /// <returns></returns>
        public static ClienteList Get()
        {
            ClienteList res = new ClienteList();

            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string query = @"SELECT * FROM Cliente 
                            INNER JOIN Persona ON Cliente.IdPersona=Persona.IdPersona 
                            WHERE Persona.Borrado=0";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new Cliente()
                    {
                        IdPersona = dr.GetInt32(0),
                        Nit = dr.GetString(1),
                        Razon = dr.GetString(2),
                        FechaRegistro = dr.GetDateTime(3),
                        Ci = dr.GetString(5),
                        Nombre = dr.GetString(6),
                        PrimerApellido = dr.GetString(7),
                        SegundoApellido = dr.GetString(8),
                        Sexo = SexoDal.Get(dr.GetInt32(9)),
                        FechaNacimiento = dr.GetDateTime(10),
                        Usuario = UsuarioDal.Get(dr.GetInt32(11)),
                        Correos = CorreoDal.GetList(dr.GetInt32(0)),
                        Telefonos = TelefonoDal.GetList(dr.GetInt32(0)),
                        Direcciones = DireccionDal.GetList(dr.GetInt32(0))
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
        /// Obtener Lista de Clientes
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static ClienteList Get(int page, int pageSize)
        {
            ClienteList res = new ClienteList();

            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string query = @"SELECT * FROM Cliente 
                            INNER JOIN Persona ON Cliente.IdPersona=Persona.IdPersona 
                            WHERE Persona.Borrado=0 ORDER BY Nombre ASC 
                            OFFSET @pageSize * (@page - 1) ROWS FETCH NEXT @pageSize ROWS ONLY";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    res.Add(new Cliente()
                    {
                        IdPersona = dr.GetInt32(0),
                        Nit = dr.GetString(1),
                        Razon = dr.GetString(2),
                        FechaRegistro = dr.GetDateTime(3),
                        Ci = dr.GetString(5),
                        Nombre = dr.GetString(6),
                        PrimerApellido = dr.GetString(7),
                        SegundoApellido = dr.GetString(8),
                        Sexo = SexoDal.Get(dr.GetInt32(9)),
                        FechaNacimiento = dr.GetDateTime(10),
                        Usuario = UsuarioDal.Get(dr.GetInt32(11)),
                        Correos = CorreoDal.GetList(dr.GetInt32(0)),
                        Telefonos = TelefonoDal.GetList(dr.GetInt32(0)),
                        Direcciones=DireccionDal.GetList(dr.GetInt32(0))
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

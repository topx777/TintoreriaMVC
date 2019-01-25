using System;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;


namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    class UsuarioDal
    {
        /// <summary>
        /// Inserta nuevo usuario
        /// </summary>
        /// <param name="usuario"></param>
        public static void Insertar(Usuario usuario)
        {
            Methods.GenerateLogsDebug("UsuarioDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un usuario"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"INSERT INTO Usuario(Username, Password, EsAdmin)
                                    VALUES(@username, @password, @esAdmin)";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@username",usuario.Username );
                command.Parameters.AddWithValue("@password", usuario.Password);
                command.Parameters.AddWithValue("@esAdmin", usuario.EsAdmin);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("UsuarioDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("UsuarioDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("UsuarioDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un usuario"));

        }

        /// <summary>
        /// Actualiza un Usuario de la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        public static void Actualizar(Usuario usuario)
        {
            Methods.GenerateLogsDebug("UsuarioDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un usuario"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Usuario SET Username=@username, Password=@password, EsAdmin=@esAdmin
                                   WHERE IdUsuario=@idUsuario";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@username", usuario.Username);
                command.Parameters.AddWithValue("@password", usuario.Password);
                command.Parameters.AddWithValue("@esAdmin", usuario.EsAdmin);
                command.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("UsuarioDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("UsuarioDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("UsuarioDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un usuario"));

        }

        /// <summary>
        /// Metodo para login de usuario
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Usuario Auth(string username, string password)
        {
            Usuario res = new Usuario();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "SELECT * FROM Usuario WHERE Username = @username AND Password = @pass";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@pass", password);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Usuario()
                    {
                        IdUsuario = dr.GetInt32(0),
                        Username = dr.GetString(1),
                        Password = dr.GetString(2),
                        EsAdmin = dr.GetBoolean(3)
                    };

                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("UsuarioDal", "Login", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }


        /// <summary>
        /// Obtiene un Trabajo de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Usuario Get(int id)
        {


            Usuario res = new Usuario();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "Select * From Usuario WHERE IdUsuario = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Usuario()
                    {
                        IdUsuario=dr.GetInt32(0),
                        Username=dr.GetString(1),
                        Password=dr.GetString(2),
                        EsAdmin=dr.GetBoolean(3)
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("UsuarioDal", "Obteber", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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

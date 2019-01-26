using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class UsuarioBrl
    {

        /// <summary>
        /// Metodo para hacer login con usuario
        /// </summary>
        /// <param name="username">Nombre de Usuario</param>
        /// <param name="password">Password para Usuario</param>
        /// <returns></returns>
        public static Usuario Auth(string username, string password)
        {
            Usuario usuario = null;
            try
            {
                usuario = UsuarioDal.Auth(username, password);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return usuario;
        }

    }
}

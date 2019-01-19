using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class CategoriaDal
    {
        /// <summary>
        /// Metodo que sirve para insertar a la base de datos
        /// </summary>
        /// <param name="categoria">Objeto paciente</param>
        public static void Insertar(Categoria categoria)
        {
            Methods.GenerateLogsDebug("CategoriaDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear una categoria"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"INSERT INTO Categoria(Nombre,Descripcion,Precio)
                                    VALUES
                                   (@nombre, @descripcion, @precio)";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombre", categoria.Nombre);
                command.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                command.Parameters.AddWithValue("@precio", categoria.Precio);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PacienteDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PacienteDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("PacienteDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un paciente"));

        }
    }
}

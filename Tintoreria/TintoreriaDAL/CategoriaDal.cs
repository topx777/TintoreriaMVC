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
        /// Metodo que sirve para insertar categoria a la base de datos
        /// </summary>
        /// <param name="categoria">Objeto Categoria</param>
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
                Methods.GenerateLogsRelease("CategoriaDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CategoriaDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("CategoriaDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un paciente"));

        }

        /// <summary>
        /// Obtiene  la informacion de una categoria
        /// </summary>
        /// <param name="id">identificador de la categoria </param>
        /// <returns></returns>
        public static Categoria Get(int id)
        {
            Categoria res = new Categoria();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "SELECT * FROM Categoria WHERE IdCategoria = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Categoria()
                    {
                        IdCategoria = dr.GetInt32(0),
                        Nombre = dr.GetString(1),
                        Descripcion = dr.GetString(2),
                        Precio = dr.GetSqlDecimal(3).ToDouble()
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CategoriaDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }


        /// <summary>
        /// Actualiza los datos de la categoria en la base de datos
        /// </summary>
        /// <param name="categoria"></param>
        public static void Actualizar(Categoria categoria)
        {
            Methods.GenerateLogsDebug("CategoriaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar una categoria"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Categoria SET Nombre=@nombre, Descripcion=@desc, Precio=@precio WHERE IdCategoria=@categoriaId";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@categoriaId", categoria.IdCategoria);
                command.Parameters.AddWithValue("@nombre", categoria.Nombre);
                command.Parameters.AddWithValue("@desc", categoria.Descripcion);
                command.Parameters.AddWithValue("@precio", categoria.Precio);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CategoriaDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CategoriaDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("CategoriaDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar una categoria"));

        }


        /// <summary>
        /// Eliminar Categoria
        /// </summary>
        /// <param name="id">Identificador de la categoria</param>
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("CategoriaDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar una categoria"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "DELETE Categoria WHERE IdCategoria=@id";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CategoriaDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CategoriaDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("CategoriaDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar una categoria"));

        }

    }
}

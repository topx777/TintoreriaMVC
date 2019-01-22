using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class PersonaDal
    {

        /// <summary>
        /// Inserta nuevo Persona a la base  de datos
        /// </summary>
        /// <param name="persona"></param>
        public static void Insertar(Persona persona)
        {
            Methods.GenerateLogsDebug("PersonaDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar una persona"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"INSERT INTO Persona(Ci, Nombre, PrimerApellido, SegundoApellido, Sexo, FechaNacimiento, Usuario)
                                  VALUES(@ci, @nombre, @primerApellido, @segundoApellido, @sexo, @fechaNacimiento, @usuario)";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@ci", persona.Ci);
                command.Parameters.AddWithValue("@nombre", persona.Nombre);
                command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
                command.Parameters.AddWithValue("@sexo", persona.Sexo);
                command.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@usuario", persona.Usuario.IdUsuario);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PersonaDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonaDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("PersonaDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar una persona"));

        }


        /// <summary>
        /// Actualiza los datos del persona en la base de datos
        /// </summary>
        /// <param name="persona"></param>
        public static void Actualizar(Persona persona)
        {
            Methods.GenerateLogsDebug("PersonaDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar una persona"));

            SqlCommand command = null;
            
            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Persona SET 
                                Ci=@ci, Nombre=@nombre, 
                                PrimerApellido=@primerApellido, 
                                SegundoApellido=@segundoApellido, 
                                Sexo=@sexo, 
                                FechaNacimiento=@fechaNacimiento, 
                                WHERE IdPersona=@idPersona";

            Usuario usuario = persona.Usuario;
            UsuarioDal.Actualizar(usuario);

            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@ci", persona.Ci);
                command.Parameters.AddWithValue("@nombre", persona.Nombre);
                command.Parameters.AddWithValue("@primerApellido", persona.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", persona.SegundoApellido);
                command.Parameters.AddWithValue("@sexo", persona.Sexo.IdSexo);
                command.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
                command.Parameters.AddWithValue("@idPersona", persona.IdPersona);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PersonaDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonaDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("PersonaDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar una persona"));

        }


        /// <summary>
        /// Eliminar Logicamente Persona de la BD
        /// </summary>
        /// <param name="id"></param>
        //Eliminado logico de Persona
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("PersonaDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un persona"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "UPDATE Persona SET Borrado = 1 WHERE IdPersona=@id";

            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PersonaDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonaDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            Methods.GenerateLogsDebug("PersonaDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para eliminar un persona"));
        }


        /// <summary>
        /// Obtiene  la informacion de una persona
        /// </summary>
        /// <param name="id">identificador de persona </param>
        /// <returns></returns>
        public static Persona Get(int id)
        {
            Persona res = new Persona();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "SELECT * FROM Persona WHERE IdPersona = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Persona()
                    {
                        IdPersona = dr.GetInt32(0),
                        Ci = dr.GetString(1),
                        Nombre = dr.GetString(2),
                        PrimerApellido = dr.GetString(3),
                        SegundoApellido = dr.GetString(4),
                        Sexo = SexoDal.Get(dr.GetInt32(5)),
                        FechaNacimiento = dr.GetDateTime(6),
                        Usuario = UsuarioDal.Get(dr.GetInt32(7)),
                        Borrado = dr.GetBoolean(8)
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonaDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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

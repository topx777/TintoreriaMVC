using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class PersonalDal
    {
        public static void Insertar(Personal personal)
        {
            Methods.GenerateLogsDebug("PersonalDal", "InsertarPersonal", string.Format("{0} Info: {1}", 
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un personal"));

            SqlCommand command = null;
            SqlTransaction trans = null;

            //Consulta para insertar datos de personal
            string queryString = @"INSERT INTO Personal(IdPersona, CodPersonal, FechaIngreso, Cargo, Sueldo) 
                               VALUES (@idPersona ,@codPersonal, @fechaIngreso, @cargo, @sueldo)";

            SqlConnection conexion = Methods.ObtenerConexion();

            try
            {
                conexion.Open();
                SqlCommand usuarioInsertcmd = UsuarioDal.InsertarOUTPUT(personal.Usuario);
                //Inicio de Conexion a la Base de Datos
                trans = conexion.BeginTransaction();

                usuarioInsertcmd.Connection = conexion;
                usuarioInsertcmd.Transaction = trans;
                personal.Usuario.IdUsuario = Convert.ToInt32(usuarioInsertcmd.ExecuteScalar());

                Persona persona = personal;

                SqlCommand personaInsertcmd = PersonaDal.InsertarOUTPUT(persona);

                personaInsertcmd.Connection = conexion;
                personaInsertcmd.Transaction = trans;
                personal.IdPersona = Convert.ToInt32(personaInsertcmd.ExecuteScalar());


                // Creacion de Personal Commando y ejecutado
                command = new SqlCommand(queryString);
                command.Parameters.AddWithValue("@idPersona", personal.IdPersona);
                command.Parameters.AddWithValue("@codPersonal", personal.CodPersonal);
                command.Parameters.AddWithValue("@fechaIngreso", personal.FechaIngreso);
                command.Parameters.AddWithValue("@cargo", personal.Cargo.IdCargo);
                command.Parameters.AddWithValue("@sueldo", personal.Sueldo);

                command.Connection = conexion;
                command.Transaction = trans;
                command.ExecuteNonQuery();

                //Insertar telefonos
                foreach (Telefono telf in personal.Telefonos)
                {
                    SqlCommand telfcmd = TelefonoDal.InsertarOUTPUT(telf, personal.IdPersona);
                    telfcmd.Connection = conexion;
                    telfcmd.Transaction = trans;
                    telfcmd.ExecuteNonQuery();
                }

                //Insertar direcciones
                foreach (Direccion direc in personal.Direcciones)
                {
                    SqlCommand direccmd = DireccionDal.InsertarOUTPUT(direc, personal.IdPersona);
                    direccmd.Connection = conexion;
                    direccmd.Transaction = trans;
                    direccmd.ExecuteNonQuery();
                }

                //Insertar correos
                foreach (Correo correo in persona.Correos)
                {
                    SqlCommand correocmd = CorreoDal.InsertarOUTPUT(correo, personal.IdPersona);
                    correocmd.Connection = conexion;
                    correocmd.Transaction = trans;
                    correocmd.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                Methods.GenerateLogsRelease("PersonalDal", "InsertarPersonal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                Methods.GenerateLogsRelease("PersonalDal", "InsertarPersonal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            Methods.GenerateLogsDebug("PersonalDal", "InsertarPersonal", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un personal"));
        }

        //Eliminado logico de Personal
        public static void Eliminar (int id)
        {
            PersonaDal.Eliminar(id);
            Methods.GenerateLogsDebug("PersonalDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un personal"));
        }

        /// <summary>
        /// Actualiza los datos del personal en la base de datos
        /// </summary>
        /// <param name="personal"></param>
        public static void Actualizar(Personal personal)
        {
            Methods.GenerateLogsDebug("PersonalDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un personal"));

            SqlCommand command = null;

            //realizar la consulta de actualiza a personal
            Persona persona = personal;
            PersonaDal.Actualizar(persona);

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Personal SET CodPersonal=@codPersonal, FechaIngreso=@fechaIngreso, Cargo=@cargo, Sueldo=@sueldo WHERE IdPersona=@idPersona";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@codPersonal", personal.CodPersonal);
                command.Parameters.AddWithValue("@fechaIngreso", personal.FechaIngreso);
                command.Parameters.AddWithValue("@cargo", personal.Cargo.IdCargo);
                command.Parameters.AddWithValue("@sueldo", personal.Sueldo);
                command.Parameters.AddWithValue("@idPersona", personal.IdPersona);
                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("PersonalDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un personal"));

        }


        /// <summary>
        /// Obtiene la informacion de un personal
        /// </summary>
        /// <param name="id">identificador del personal </param>
        /// <returns></returns>
        public static Personal Get(int id)
        {
            Personal res = new Personal();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = "SELECT * FROM Personal WHERE IdPersona = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Personal()
                    {
                        IdPersona = dr.GetInt32(0),
                        CodPersonal = dr.GetString(1),
                        FechaIngreso = dr.GetDateTime(2),
                        Cargo = CargoDal.Get(dr.GetInt32(3)),
                        Sueldo = dr.GetDecimal(4)
                    };
                }

                Persona persona = PersonaDal.Get(res.IdPersona);
                res.Ci = persona.Ci;
                res.Nombre = persona.Nombre;
                res.PrimerApellido = persona.PrimerApellido;
                res.SegundoApellido = persona.SegundoApellido;
                res.Sexo = persona.Sexo;
                res.FechaNacimiento = persona.FechaNacimiento;
                res.Usuario = persona.Usuario;
                res.Borrado = persona.Borrado;

                res.Correos = CorreoDal.GetList(res.IdPersona);
                res.Telefonos = TelefonoDal.GetList(res.IdPersona);
                res.Direcciones = DireccionDal.GetList(res.IdPersona);
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return res;
        }



        /// <summary>
        /// Obtiene Lista de Personal
        /// </summary>
        /// <returns>Lista de Objetos Personal</returns>
        public static List<Personal> GetList()
        {
            List<Personal> res = new List<Personal>();

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Personal INNER JOIN Persona 
                            ON Personal.IdPersona = Persona.IdPersona WHERE Persona.Borrado = 0";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    int idPersona = dr.GetInt32(0);
                    Persona persona = PersonaDal.Get(idPersona);

                    res.Add(new Personal()
                    {
                        IdPersona = idPersona,
                        Ci = persona.Ci,
                        Nombre = persona.Nombre,
                        PrimerApellido = persona.PrimerApellido,
                        SegundoApellido = persona.SegundoApellido,
                        Sexo = persona.Sexo,
                        FechaNacimiento = persona.FechaNacimiento,
                        Correos = persona.Correos,
                        Usuario = persona.Usuario,
                        Direcciones = persona.Direcciones,
                        Telefonos = persona.Telefonos,
                        Borrado = persona.Borrado,
                        CodPersonal = dr.GetString(1),
                        FechaIngreso = dr.GetDateTime(2),
                        Cargo = CargoDal.Get(dr.GetInt32(3)),
                        Sueldo = dr.GetDecimal(4)
                    });
                }
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
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

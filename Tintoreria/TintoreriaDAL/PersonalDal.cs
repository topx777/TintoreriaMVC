using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class PersonalDal
    {
        public static void Insertar(Personal personal, List<Telefono> telefonos, List<Direccion> direcciones, List<Correo> correos)
        {
            Methods.GenerateLogsDebug("PersonalDal", "InsertarPersonal", string.Format("{0} Info: {1}", 
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un personal"));

            SqlCommand command = null;

            //Consulta para insertar datos de personal
            string queryString = @"INSERT INTO Personal(IdPersona, CodPersonal, FechaIngreso, Cargo, Sueldo) 
                               VALUES (@idPersona ,@codPersonal, @fechaIngreso, @cargo, @sueldo)";
            try
            {
                UsuarioDal.Insertar(personal.Usuario);
                
                personal.Usuario.IdUsuario = Methods.GetActIDTable("Usuario");

                Persona persona = personal;
                PersonaDal.Insertar(persona);

                personal.IdPersona = Methods.GetActIDTable("Persona");

                //Insertar telefonos
                foreach(Telefono telf in telefonos)
                {
                    TelefonoDal.Insertar(telf, personal.IdPersona);
                }

                //Insertar direcciones
                foreach(Direccion direc in direcciones)
                {
                    DireccionDal.Insertar(direc, personal.IdPersona);
                }

                //Insertar correos
                foreach (Correo correo in correos)
                {
                    CorreoDal.Insertar(correo, personal.IdPersona);
                }

                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idPersona", personal.IdPersona);
                command.Parameters.AddWithValue("@codPersonal", personal.CodPersonal);
                command.Parameters.AddWithValue("@fechaIngreso", personal.FechaIngreso);
                command.Parameters.AddWithValue("@cargo", personal.Cargo.IdCargo);
                command.Parameters.AddWithValue("@sueldo", personal.Sueldo);
                Methods.ExecuteBasicCommand(command);
                
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "InsertarPersonal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("PersonalDal", "InsertarPersonal", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
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
        /// Obtine  la informacion de un personal
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
                        Cargo = Cargo.Get(dr.GetInt32(3)),
                        Sueldo = dr.GetSqlDecimal(4).ToDouble()
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
    }
}

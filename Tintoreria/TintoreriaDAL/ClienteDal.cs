using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class ClienteDal
    {
        /// <summary>
        /// Inserta nuevo Cliente a la base  de datos
        /// </summary>
        /// <param name="cliente"></param>
        public static void Insertar(Cliente cliente, List<Telefono> telefonos, List<Direccion> direcciones)
        {
            Methods.GenerateLogsDebug("ClienteDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Insertar un paciente"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"INSERT INTO Cliente(IdPersona, Nit, Razon, FechaRegistro) VALUES (@idPersona ,@nit, @razon, @fechaRagistro)";
            try
            {
                UsuarioDal.Insertar(cliente.Usuario);
                cliente.Usuario.IdUsuario = Methods.GetActIDTable("Usuario");

                Persona persona = cliente;
                PersonaDal.Insertar(persona);
                cliente.IdPersona = Methods.GetActIDTable("Persona");

                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idPersona",cliente.IdPersona);
                command.Parameters.AddWithValue("@nit", cliente.Nit);
                command.Parameters.AddWithValue("@razon", cliente.Razon);
                command.Parameters.AddWithValue("@fechaRegistro", cliente.FechaRegistro);
                Methods.ExecuteBasicCommand(command);

                foreach (Telefono telefono in telefonos)
                {
                    TelefonoDal.Insertar(telefono, cliente.IdPersona);
                }
                foreach (Direccion direccion in direcciones)
                {
                    DireccionDal.Insertar(direccion, cliente.IdPersona);
                }
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("ClienteDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un Cliente"));

        }

        /// <summary>
        /// Elimina de forma logica un cliente de la base de datos
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("ClienteDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Cliente"));

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
                Methods.GenerateLogsRelease("ClienteDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

                Methods.GenerateLogsDebug("ClienteDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un Cliente"));

        }

        /// <summary>
        /// Actualiza un Cliente de la base de datos
        /// </summary>
        /// <param name="cliente"></param>
        public static void Actualizar(Cliente cliente)
        {
            Methods.GenerateLogsDebug("ClienteDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un Cliente"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Usuario SET Username=@username, Password=@password, EsAdmin=@esAdmin 
                                    WHERE IdUsuario=@idUsuario";
            string queryString1 = @"UPDATE Persona SET Nombre=@nombre, PrimerApellido=@primerApellido, SegundoApellido=@segundoApellido, 
                                    Sexo=@sexo, FechaNacimiento=@fechaNacimiento, Correo=@correo, Usuario=@usuario
                                    WHERE IdPersona=@idPersona";
            string queryString2 = @"UPDATE Cliente SET Nit=@nit, Razon=@razon, FechaRegistro=@fechaRegistro 
                                    WHERE @IdPersona=@idPersona";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@username", cliente.Usuario.Username);
                command.Parameters.AddWithValue("@password", cliente.Usuario.Password);
                command.Parameters.AddWithValue("@esAdmin", cliente.Usuario.EsAdmin);
                command.Parameters.AddWithValue("@idUsuario", cliente.Usuario.IdUsuario);
                Methods.ExecuteBasicCommand(command);

                command = Methods.CreateBasicCommand(queryString1);
                command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@primerApellido", cliente.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", cliente.SegundoApellido);
                command.Parameters.AddWithValue("@sexo",cliente.Sexo);
                command.Parameters.AddWithValue("@fechaNacimiento", cliente.FechaNacimiento);
                command.Parameters.AddWithValue("@correo", cliente.Correo);
                command.Parameters.AddWithValue("@usuario",cliente.Usuario.IdUsuario);
                command.Parameters.AddWithValue("@idPersona", cliente.IdPersona);
                Methods.ExecuteBasicCommand(command);

                command = Methods.CreateBasicCommand(queryString2);
                command.Parameters.AddWithValue("@nit", cliente.Nit);
                command.Parameters.AddWithValue("@razon", cliente.Razon);
                command.Parameters.AddWithValue("@fechaRegistro", cliente.FechaRegistro);
                command.Parameters.AddWithValue("@idPersona", cliente.IdPersona);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

                Methods.GenerateLogsDebug("ClienteDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un paciente"));

        }

        /// <summary>
        /// Obtiene un Cliente de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Cliente Get(int id)
        {
            Cliente res = new Cliente();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"Select Persona.*,
                                    Cliente.Nit, Cliente.Razon, Cliente.FechaRegistro
                            FROM Persona 
                            INNER JOIN Cliente ON Persona.IdPersona=Cliente.IdPersona
                            WHERE Cliente.IdPersona=@id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Cliente()
                    {
                        IdPersona=dr.GetInt32(0),
                        Nombre=dr.GetString(1),
                        PrimerApellido=dr.GetString(2),
                        SegundoApellido=dr.GetString(3),
                        Sexo=dr.GetString(4),
                        FechaNacimiento=dr.GetDateTime(5),
                        Correo=dr.GetString(6),
                        //Usuario=UsuarioDal.Get(dr.GetInt32(7)),
                        //Direcciones=DireccionListDal(dr.GetInt32(0)),
                        //Telefonos=TelefonoListDal(dr.GetInt32(0)),
                        Borrado=dr.GetBoolean(7),
                        Nit=dr.GetInt32(8),
                        Razon=dr.GetString(9),
                        FechaRegistro=dr.GetDateTime(10)
                        

                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("ClienteDal", "Obtenet(Get)", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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

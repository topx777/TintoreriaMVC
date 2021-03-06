﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    /// <summary>
    /// Clase que permite interactuar con la Base de Datos de Trabajo
    /// </summary>
    public class TrabajoDal
    {
        /// <summary>
        /// Inserta nuevo trabajo
        /// </summary>
        /// <param name="trabajo"></param>
        public static void Insertar(Trabajo trabajo)
        {
            Methods.GenerateLogsDebug("TrabajoDal", "Insertar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para insertar un Trabajo"));

            SqlCommand command = null;
            SqlTransaction trans = null;

            string queryString = "";

            // Proporcionar la cadena de consulta 
            if(trabajo.PedidoDistancia != null)
            {
                queryString = @"INSERT INTO Trabajo(Cliente, FechaTrabajo, TotalPrecio, FechaEntrega, PedidoDistancia, EntregaDomicilio)
                                    OUTPUT inserted.IdTrabajo
                                    VALUES
                                   (@Cliente, @FechaTrabajo, @TotalPrecio, @FechaEntrega, @PedidoDistancia, @EntregaDomicilio)";
            }
            else
            {
                queryString = @"INSERT INTO Trabajo(Cliente, FechaTrabajo, TotalPrecio, FechaEntrega, EntregaDomicilio)
                                    OUTPUT inserted.IdTrabajo
                                    VALUES
                                   (@Cliente, @FechaTrabajo, @TotalPrecio, @FechaEntrega, @EntregaDomicilio)";
            }

            SqlConnection conexion = Methods.ObtenerConexion();

            try
            {
                conexion.Open();

                trans = conexion.BeginTransaction();

                command = new SqlCommand(queryString);
                command.Parameters.AddWithValue("@Cliente", trabajo.Cliente.IdPersona);
                command.Parameters.AddWithValue("@FechaTrabajo", DateTime.Now);
                command.Parameters.AddWithValue("@TotalPrecio", trabajo.TotalPrecio);
                command.Parameters.AddWithValue("@FechaEntrega", trabajo.FechaEntrega);
                if(trabajo.PedidoDistancia != null)
                {
                    command.Parameters.AddWithValue("@PedidoDistancia", trabajo.PedidoDistancia != null ? trabajo.PedidoDistancia.IdPedido : null);
                }
                command.Parameters.AddWithValue("@EntregaDomicilio", trabajo.EntregaDomicilio);

                command.Connection = conexion;
                command.Transaction = trans;
                //Methods.ExecuteBasicCommand(command);

                int idTrabajo = Convert.ToInt32(command.ExecuteScalar());

                foreach(TrabajoDetalle trabajod in trabajo.TrabajoDetalle)
                {
                    trabajod.Estado = new Estado()
                    {
                        IdEstado = 1
                    };

                    SqlCommand cmdtmp = TrabajoDetalleDal.InsertarCMD(trabajod, idTrabajo);
                    cmdtmp.Connection = conexion;
                    cmdtmp.Transaction = trans;
                    cmdtmp.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                trans.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                trans.Rollback();
                throw ex;
            }

            Methods.GenerateLogsDebug("TrabajoDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un trabajo"));

        }

        /// <summary>
        /// Elimina trabajo ya existente
        /// </summary>
        /// <param name="id">Identificador de Trabajo</param>
        public static void Eliminar(int id)
        {
            Methods.GenerateLogsDebug("TrabajoDal", "Eliminar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para eliminar un Trabajo"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = "UPDATE Trabajo SET Borrado = 1 WHERE IdTrabajo=@id";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@id", id);
                Methods.ExecuteBasicCommand(command);

                List<TrabajoDetalle> trabajos = TrabajoDetalleDal.GetList(id);

                foreach(TrabajoDetalle x in trabajos)
                {
                    TrabajoDetalleDal.Eliminar(x.IdTrabajoDetalle);
                }
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("TrabajoDal", "Eliminar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Eliminar un cliente"));
        }

        /// <summary>
        /// Obtiene la cantidad total de registros de la BD
        /// </summary>
        /// <returns></returns>
        public static int Count()
        {
            SqlCommand cmd = null;

            int count = 0;

            string queryString = "SELECT COUNT(*) FROM Trabajo WHERE Borrado = 0";

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
                Methods.GenerateLogsRelease("TrabajoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("TrabajoDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar un trabajo"));

            return count;
        }

        /// <summary>
        /// Actualiza un trabajo de la base de datos
        /// </summary>
        /// <param name="trabajo"></param>
        public static void Actualizar(Trabajo trabajo)
        {
            Methods.GenerateLogsDebug("TrabajoDal", "Actualizar", string.Format("{0} Info: {1}", DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para Actualizar un Trabajo"));

            SqlCommand command = null;

            // Proporcionar la cadena de consulta 
            string queryString = @"UPDATE Trabajo SET Cliente=@cliente, 
                                    FechaTrabajo=@fechaTrabajo,
                                    TotalPrecio=@totalPrecio, 
                                    FechaEntrega=@fechaEntrega, 
                                    PedidoDistancia=@pedidoDistancia, 
                                    EntregaDomicilio=@entregaDomicilio
                                    Where IdTrabajo=@idTrabajo";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@cliente", trabajo.Cliente.IdPersona);
                command.Parameters.AddWithValue("@fechaTrabajo", trabajo.FechaTrabajo);
                command.Parameters.AddWithValue("@totalPrecio", trabajo.TotalPrecio);
                command.Parameters.AddWithValue("@fechaEntrega", trabajo.FechaEntrega);
                command.Parameters.AddWithValue("@pedidoDistancia", trabajo.PedidoDistancia.IdPedido);
                command.Parameters.AddWithValue("@entregaDomicilio", trabajo.EntregaDomicilio);
                command.Parameters.AddWithValue("@idTrabajo", trabajo.IdTrabajo);

                Methods.ExecuteBasicCommand(command);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

                Methods.GenerateLogsDebug("TrabajoDal", "Actualizar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para Actualizar un Trabajo"));

        }

        /// <summary>
        /// Obtiene un Trabajo de la base de datos
        /// </summary>
        /// <param name="id">Idenficador de Trabajo</param>
        /// <returns></returns>
        public static Trabajo Get(int id)
        {
            Trabajo res = new Trabajo();
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Trabajo WHERE IdTrabajo = @id";
            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@id", id);
                dr = Methods.ExecuteDataReaderCommand(cmd);
                while (dr.Read())
                {
                    res = new Trabajo()
                    {
                        IdTrabajo = dr.GetInt32(0),
                        Cliente = ClienteDal.Get(dr.GetInt32(1)),
                        FechaTrabajo = dr.GetDateTime(2),
                        TotalPrecio = dr.GetDecimal(3),
                        FechaEntrega = dr.GetDateTime(4),
                        PedidoDistancia = dr.IsDBNull(5) ? null : PedidoDal.Get(dr.GetInt32(5)),
                        EntregaDomicilio = dr.GetBoolean(6),
                        Borrado = dr.GetBoolean(7),
                        TrabajoDetalle = TrabajoDetalleDal.GetList(dr.GetInt32(0))
                    };
                }
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "Obtener", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
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
        public static List<Trabajo> GetList()
        {
            List<Trabajo> res = new List<Trabajo>();

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Trabajo WHERE Borrado = 0";

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    int idTrabajo = dr.GetInt32(0);

                    res.Add(new Trabajo()
                    {
                        IdTrabajo = idTrabajo,
                        Cliente = ClienteDal.Get(dr.GetInt32(1)),
                        FechaTrabajo = dr.GetDateTime(2),
                        TotalPrecio = dr.GetDecimal(3),
                        FechaEntrega = dr.GetDateTime(4),
                        PedidoDistancia = PedidoDal.Get(dr.GetInt32(5)),
                        EntregaDomicilio = dr.GetBoolean(6),
                        TrabajoDetalle = TrabajoDetalleDal.GetList(idTrabajo),
                        Borrado = dr.GetBoolean(7)
                    });
                }
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }

            return res;
        }


        /// <summary>
        /// Obtiene Lista de Personal con paginado
        /// </summary>
        /// <param name="pageSize">Siguiente cantidad de resultados</param>
        /// <param name="page">Inicio resultado</param>
        /// <returns>Lista de Objetos Personal</returns>
        public static TrabajoList GetLista(int page, int pageSize)
        {
            TrabajoList res = new TrabajoList();

            SqlCommand cmd = null;
            SqlDataReader dr = null;
            string query = @"SELECT * FROM Trabajo WHERE Borrado = 0 ORDER BY IdTrabajo 
                        OFFSET @pageSize * (@page - 1) ROWS FETCH NEXT @pageSize ROWS ONLY";
            //string query = @"SELECT * FROM Trabajo WHERE Borrado = 0 ORDER BY IdTrabajo;";

            try
            {
                cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@page", page);
                cmd.Parameters.AddWithValue("@pageSize", pageSize);
                dr = Methods.ExecuteDataReaderCommand(cmd);

                while (dr.Read())
                {
                    int idTrabajo = dr.GetInt32(0);

                    res.Add(new Trabajo()
                    {
                        IdTrabajo = idTrabajo,
                        Cliente = ClienteDal.Get(dr.GetInt32(1)),
                        FechaTrabajo = dr.GetDateTime(2),
                        TotalPrecio = dr.GetDecimal(3),
                        FechaEntrega = dr.GetDateTime(4),
                        PedidoDistancia = dr.IsDBNull(5) ? null : PedidoDal.Get(dr.GetInt32(5)),
                        EntregaDomicilio = dr.GetBoolean(6),
                        //TrabajoDetalle = TrabajoDetalleDal.GetList(idTrabajo),
                        Borrado = dr.GetBoolean(7)
                    });
                }
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("TrabajoDal", "ObtenerLista", ex.Message + " " + ex.StackTrace);
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

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL;


namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL
{
    public class CargoBrl
    {
        //metodo para insertar cargo
        public static void Insertar(Cargo cargo)
        {
            try
            {
                CargoDal.Insertar(cargo);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }


        //Metodo para obtener categoria

        public static List<Cargo> Get()
        {
            List<Cargo> cargoList = null;
            try
            {
                cargoList = CargoDal.GetList();
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "ListCargo",
                string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(),
                DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "ListCargo", string.Format("{0} {1} Error: {2}",
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            return cargoList;
        }


        //Metodo para obtener categoria

        public static Cargo Get(int id)
        {
            Cargo cargo = null;
            try
            {
                cargo = CargoDal.Get(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return cargo;
        }

        //Actualiza datos de cargo en la base de datos
        public static void Actualizar(Cargo cargo)
        {
            try
            {
                CargoDal.Actualizar(cargo);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "Actualizar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
        }

        //metodo para eliminar un cargo
        public static void Eliminar(int id)
        {
            try
            {
                CargoDal.Eliminar(id);
            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("CargoBrl", "Eliminar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

        }
    }
}

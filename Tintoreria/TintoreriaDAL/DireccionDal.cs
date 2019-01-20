using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class DireccionDal
    {
        public static void Insertar(Direccion direccion, int idPersona)
        {
            Methods.GenerateLogsDebug("DireccionDal", "Insertar", string.Format("{0} Info: {1}",
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear una direccion"));

            SqlCommand command = null;

            //Consulta para insertar telefonos
            string queryString = @"INSERT INTO Direccion(IdDireccion, Descripcion, Tipo, Latitud, Longitud, idPersona) VALUES(@idDireccion, @desc, @tipo, @latitud, @longitud, @idPersona)";

            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@idTelefono", direccion.IdDireccion);
                command.Parameters.AddWithValue("@desc", direccion.Descripcion);
                command.Parameters.AddWithValue("@tipo", direccion.Tipo);
                command.Parameters.AddWithValue("@latitud", direccion.Latitud);
                command.Parameters.AddWithValue("@longitud", direccion.Longitud);
                command.Parameters.AddWithValue("@idPersona", idPersona);
                Methods.ExecuteBasicCommand(command);

            }
            catch (SqlException ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                Methods.GenerateLogsRelease("DireccionDal", "Insertar", string.Format("{0} {1} Error: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

            Methods.GenerateLogsDebug("DireccionDal", "Insertar", string.Format("{0} {1} Info: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), "Termino de ejecutar  el metodo acceso a datos para insertar una direccion"));
        }
    }
}

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
        public static void InsertarPersonal(Personal personal )
        {
            Methods.GenerateLogsDebug("PersonalaDal", "InsertarPersonal", string.Format("{0} Info: {1}", 
            DateTime.Now.ToLongDateString(), "Empezando a ejecutar el metodo acceso a datos para crear un personal"));

            SqlCommand command = null;

            //Consulta para insertar datos de personal
            string queryString = @"INSERT INTO  (Nombre,PrimerApellido,SegundoApellido,Sexo,FechaNacimiento,Correo,
                                 CodPersonal,Ci,FechaIngreso,Cargo,Sueldo,Turno)
                                 VALUES
                                 (@nombre, @primerApellido, @segundoApellido, @sexo, @fechaNacimiento, @correo,
                                 @codPersonal, @ci, fechaIngreso, @cargo, @sueldo, @turno)";
            try
            {
                command = Methods.CreateBasicCommand(queryString);
                command.Parameters.AddWithValue("@nombre", personal.Nombre);
                command.Parameters.AddWithValue("@PrimerApellido", personal.PrimerApellido);
                command.Parameters.AddWithValue("@segundoApellido", personal.SegundoApellido);
                command.Parameters.AddWithValue("@sexo", personal.Sexo);
                command.Parameters.AddWithValue("@fechaNacimiento", personal.FechaNacimiento);
                command.Parameters.AddWithValue("@correo", personal.Correo);
                command.Parameters.AddWithValue("@codPersonal", personal.CodPersonal);
                command.Parameters.AddWithValue("@ci", personal.Ci);
                command.Parameters.AddWithValue("@fechaIngreso", personal.FechaIngreso);
                command.Parameters.AddWithValue("@cargo", personal.Cargo);
                command.Parameters.AddWithValue("@sueldo", personal.Sueldo);
                command.Parameters.AddWithValue("@turno", personal.Turno);
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
    }
}

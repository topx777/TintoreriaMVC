using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Upds.Sistemas.ProgWeb2.Tintoreria.Core;


namespace Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaDAL
{
    public class PersonalListDal
    {
        public static PersonalList Get()
        {
            PersonalList res = new PersonalList();

            SqlCommand cmd = null;
            SqlDataReader dr = null;

            string query = "SELECT * FROM Personal";
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
                        Sueldo = dr.GetSqlDecimal(4).ToDouble()
                    });
                }
            }
            catch (SqlException ex)
            {
                //Methods.GenerateLogsRelease("KeyValuePacienteListDal", "Obtener", ex.Message + " " + ex.StackTrace);
                throw ex;
            }
            catch (Exception ex)
            {
                //Methods.GenerateLogsRelease("KeyValuePacienteListDal", "Obtener", ex.Message + " " + ex.StackTrace);
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

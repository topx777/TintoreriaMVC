using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class PersonalListModel:List<PersonalModel>
    {
        /// <summary>
        /// Necesita ser public, cuidado todo en poner public
        /// </summary>
        /// <returns></returns>
        public static PersonalListModel Get()
        {
            PersonalListModel _personalListModel = new PersonalListModel();
            foreach (var personal in PersonalListBrl.Get())
            {
                _personalListModel.Add(new PersonalModel
                {
                    IdPersona = personal.IdPersona,
                    Ci = personal.Ci,
                    Nombre = personal.Nombre,
                    PrimerApellido = personal.PrimerApellido,
                    SegundoApellido = personal.SegundoApellido,
                    FechaNacimiento = personal.FechaNacimiento,     
                    CodPersonal = personal.CodPersonal,
                    FechaIngreso=personal.FechaIngreso,
                    Sueldo=personal.Sueldo,
                              
                });
            }
            return _personalListModel;
        }
    }
}
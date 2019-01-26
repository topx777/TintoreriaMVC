using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class CargoListModel : List<CargoModel>
    {
        /// <summary>
        /// Necesita ser public, cuidado todo en poner public
        /// </summary>
        /// <returns></returns>
        public static CargoListModel Get()
        {
            CargoListModel _cargoListModel = new CargoListModel();
            foreach (var cargo in CargoListBrl.Get())
            {
                _cargoListModel.Add(new CargoModel
                {
                    IdCargo = cargo.IdCargo,
                    Nombre = cargo.Nombre,
                });
            }
            return _cargoListModel;
        }
    }
}
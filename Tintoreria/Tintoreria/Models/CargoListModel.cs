using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class CargoListModel : List<CargoModel>
    {
        public static CargoListModel Get()
        {
            CargoListModel _categoriaListModel = new CargoListModel();
            foreach (var cargo in CargoListBrl.Get())
            {
                _categoriaListModel.Add(new CategoriaModel
                {
                    IdCargo= cargo.IdCargo,
                    Nombre = cargo.Nombre,
                });
            }
            return _cargoListModel;
        }
    }
}
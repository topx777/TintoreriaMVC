using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class CategoriaListModel : List<CategoriaModel>
    {
        public Pager Pager { get; set; }

        /// <summary>
        /// Necesita ser public, cuidado todo en poner public
        /// </summary>
        /// <returns></returns>
        public static CategoriaListModel Get(int page, int pageSize = 10)
        {
            CategoriaListModel _categoriaListModel = new CategoriaListModel() ;
            foreach (var categoria in CategoriaListBrl.Get(page, pageSize))
            {
                _categoriaListModel.Add(new CategoriaModel
                {
                    IdCategoria = categoria.IdCategoria,
                    Nombre = categoria.Nombre,
                    Descripcion = categoria.Descripcion,
                    Precio = categoria.Precio
                });
            }
            
            _categoriaListModel.Pager = new Pager(CategoriaListBrl.Count(), page);

            return _categoriaListModel;
        }


    }
}
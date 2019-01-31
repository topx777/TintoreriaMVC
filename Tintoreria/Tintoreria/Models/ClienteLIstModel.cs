using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class ClienteListModel:List<ClienteModel>
    {
        public Pager Pager { get; set; }


        //public static ClienteListModel Get()
        //{

        //    ClienteListModel clienteListModel = new ClienteListModel();
        //    foreach (var cliente in ClienteBrl.ListCliente())
        //    {
        //        clienteListModel.Add(new ClienteModel {
        //            IdPersona=cliente.IdPersona,
        //            Nombre=cliente.Nombre,
        //            PrimerApellido=cliente.PrimerApellido,
        //            SegundoApellido= cliente.SegundoApellido,
        //            Ci=cliente.Ci
        //        });
        //    }

        //    return clienteListModel;
        //}

        public static ClienteListModel Get(int page, int pageSize = 10)
        {
            ClienteListModel _clienteListModel = new ClienteListModel();
            foreach (var cliente in ClienteListBrl.Get(page, pageSize))
            {
                _clienteListModel.Add(new ClienteModel
                {
                    IdPersona=cliente.IdPersona,
                    Nombre=cliente.Nombre,
                    PrimerApellido=cliente.PrimerApellido,
                    SegundoApellido=cliente.SegundoApellido,
                    Ci=cliente.Ci
                    
                });
            }

            _clienteListModel.Pager = new Pager(ClienteListBrl.Count(), page);

            return _clienteListModel;
        }
    }
}
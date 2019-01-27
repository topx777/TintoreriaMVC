using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;
namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class ClienteListModel:List<ClienteModel>
    {
        public static ClienteListModel Get()
        {
            ClienteListModel clienteListModel = new ClienteListModel();
            foreach (var cliente in ClienteBrl.ListCliente())
            {
                clienteListModel.Add(new ClienteModel {
                    IdPersona=cliente.IdPersona,
                    Nombre=cliente.Nombre,
                    PrimerApellido=cliente.PrimerApellido,
                    SegundoApellido= cliente.SegundoApellido,
                    Ci=cliente.Ci
                });
            }

            return clienteListModel;
        }
    }
}
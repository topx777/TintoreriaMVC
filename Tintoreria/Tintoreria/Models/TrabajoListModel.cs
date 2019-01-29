using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class TrabajoListModel
    {
        /// <summary>
        /// Necesita ser public, cuidado todo en poner public
        /// </summary>
        /// <returns></returns>
        public static TrabajoListModel Get(int offset, int next)
        {
            TrabajoListModel _trabajoListModel = new TrabajoListModel();
            foreach (var trabajo in TrabajoListBrl.Get(offset, next))
            {
                _trabajoListModel.Add(new TrabajoModel
                {
                    IdTrabajo = trabajo.IdTrabajo,
                    Cliente =
                    {
                        IdPersona = trabajo.Cliente.IdPersona
                    },
                    FechaTrabajo = trabajo.FechaTrabajo,
                    TotalPrecio = trabajo.TotalPrecio,
                    FechaEntrega = trabajo.FechaEntrega,
                    PedidoDistancia =
                    {
                        IdPedido =  trabajo.PedidoDistancia.IdPedido,
                        Recepcion = trabajo.PedidoDistancia.Recepcion,
                        PrecioPedido = trabajo.PedidoDistancia.PrecioPedido,
                        DireccionPedido =
                        {
                            IdDireccion = trabajo.PedidoDistancia.DireccionPedido.IdDireccion,
                            Descripccion = trabajo.PedidoDistancia.DireccionPedido.Descripcion,
                            Latitud = trabajo.PedidoDistancia.DireccionPedido.Latitud,
                            Longitud = trabajo.PedidoDistancia.DireccionPedido.Longitud,
                            Tipo =
                            {
                                
                            }
                        }
                        
                    },
                    EntregaDomicilio = trabajo.EntregaDomicilio,
                    Borrado = trabajo.Borrado
                });
            }
            return _trabajoListModel;
        }
    }
}
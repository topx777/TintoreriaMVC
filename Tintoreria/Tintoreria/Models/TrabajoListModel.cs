using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Upds.Sistemas.ProgWeb2.Tintoreria.TintoreriaBRL;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class TrabajoListModel : List<TrabajoModel>
    {
        public Pager Pager { get; set; }
        /// <summary>
        /// Necesita ser public, cuidado todo en poner public
        /// </summary>
        /// <returns></returns>
        public static TrabajoListModel Get(int page, int pageSize = 10)
        {
            TrabajoListModel _trabajoListModel = new TrabajoListModel();
            foreach (var trabajo in TrabajoListBrl.Get(page, pageSize))
            {
                _trabajoListModel.Add(new TrabajoModel()
                {
                    IdTrabajo = trabajo.IdTrabajo,
                    Cliente = new ClienteModel()
                    {
                        IdPersona = trabajo.Cliente.IdPersona,
                        Ci = trabajo.Cliente.Ci,
                        Nombre = trabajo.Cliente.Nombre,
                        PrimerApellido = trabajo.Cliente.PrimerApellido,
                        SegundoApellido = trabajo.Cliente.SegundoApellido,
                        FechaNacimiento = trabajo.Cliente.FechaNacimiento,
                        Usuario = new UsuarioModel()
                        {
                            IdUsuario = trabajo.Cliente.Usuario.IdUsuario,
                            Username = trabajo.Cliente.Usuario.Username,
                            Password = trabajo.Cliente.Usuario.Password,
                            EsAdmin = trabajo.Cliente.Usuario.EsAdmin
                        },
                        FechaRegistro = trabajo.Cliente.FechaRegistro,
                        Nit = trabajo.Cliente.Nit,
                        Razon = trabajo.Cliente.Razon,
                        Sexo = new SexoModel()
                        {
                            IdSexo = trabajo.Cliente.Sexo.IdSexo,
                            Nombre = trabajo.Cliente.Sexo.Nombre
                        },
                        Borrado = trabajo.Cliente.Borrado
                    },
                    FechaTrabajo = trabajo.FechaTrabajo,
                    TotalPrecio = trabajo.TotalPrecio,
                    FechaEntrega = trabajo.FechaEntrega,
                    PedidoDistancia = new PedidoModel()
                    {
                        IdPedido =  trabajo.PedidoDistancia.IdPedido,
                        Recepcion = trabajo.PedidoDistancia.Recepcion,
                        PrecioPedido = trabajo.PedidoDistancia.PrecioPedido,
                        DireccionPedido = new DireccionModel()
                        {
                            IdDireccion = trabajo.PedidoDistancia.DireccionPedido.IdDireccion,
                            Descripccion = trabajo.PedidoDistancia.DireccionPedido.Descripcion,
                            Latitud = trabajo.PedidoDistancia.DireccionPedido.Latitud,
                            Longitud = trabajo.PedidoDistancia.DireccionPedido.Longitud,
                            Tipo = new TipoModel()
                            {
                                IdTipo = trabajo.PedidoDistancia.DireccionPedido.Tipo.IdTipo,
                                Nombre = trabajo.PedidoDistancia.DireccionPedido.Tipo.Nombre
                            }
                        }
                    },
                    EntregaDomicilio = trabajo.EntregaDomicilio,
                    Borrado = trabajo.Borrado
                });
            }

            _trabajoListModel.Pager = new Pager(TrabajoListBrl.Count(), page);

            return _trabajoListModel;
        }
    }
}
using System;
using System.Collections.Generic;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class Trabajo
    {
        #region Atributos

        public int IdTrabajo { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaTrabajo { get; set; }
        public double TotalPrecio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Pedido PedidoDistancia { get; set; }
        public bool EntregaDomicilio { get; set; }
        public List<TrabajoDetalle> TrabajoDetalle { get; set; }
        public bool Borrado { get; set; }

        #endregion

    }
}

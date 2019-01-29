namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class Pedido
    {
        #region Atributos

        public int? IdPedido { get; set; }
        public string Recepcion { get; set; }
        public decimal PrecioPedido { get; set; }
        public Direccion DireccionPedido { get; set; }

        #endregion
    }
}

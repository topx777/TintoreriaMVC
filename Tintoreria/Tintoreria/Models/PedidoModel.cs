using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class PedidoModel
    {

        #region Atributos
        [Key]
        [Display(Name = "ID Pedido")]
        public int? IdPedido { get; set; }

        [Display(Name = "Recepcion")]
        [StringLength(25, ErrorMessage = "Numero maximo de caracteres es de 25")]
        public string Recepcion { get; set; }

        [Display(Name = "Precio Pedido")]
        [Range(0, 99999999.99, ErrorMessage = "Precio sobrepasa valores permitidos.")]
        public decimal PrecioPedido { get; set; }

        public DireccionModel DireccionPedido { get; set; }

        #endregion

    }
}
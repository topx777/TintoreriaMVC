using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class TrabajoModel
    {

        public TrabajoModel()
        {
            this.TrabajoDetalle = new List<TrabajoDetalleModel>();
        }

        #region Atributos

        [Key]
        [Display(Name = "IdTrabajo")]
        public int IdTrabajo { get; set; }
        
        public ClienteModel Cliente { get; set; }
        
        [Display(Name = "Fecha Trabajo")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaTrabajo { get; set; }
        
        [Display(Name = "Total Precio")]
        [Range(0, 99999999.99, ErrorMessage = "El total precio no debe ser negativo")]
        public decimal TotalPrecio { get; set; }

        [Display(Name = "Fecha Entrega")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaEntrega { get; set; }

        public PedidoModel PedidoDistancia { get; set; }

        [Display(Name = "Entrega Domicilio")]
        public bool EntregaDomicilio { get; set; }

        public List<TrabajoDetalleModel> TrabajoDetalle { get; set; }

        [Display(Name = "Borrado")]
        public bool Borrado { get; set; }

        #endregion   
    }
}
﻿namespace Upds.Sistemas.ProgWeb2.Tintoreria.Core
{
    public class TrabajoDetalle
    {

        #region Atributos

        public int IdTrabajoDetalle { get; set; }
        public string CodigoPrenda { get; set; }
        public Categoria Categoria { get; set; }
        public decimal PrecioFinal { get; set; }
        public double Peso { get; set; }
        public Estado Estado { get; set; }
        public bool Borrado { get; set; }

        #endregion
    }
}

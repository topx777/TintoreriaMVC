﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Upds.Sistemas.ProgWeb2.Tintoreria.MVC.Models
{
    public class DireccionModel
    {
        [Display(Name ="Id Direccion")]
        public int IdDireccion { get; set; }

        [Display(Name ="Descripccion")]
        public string Descripccion { get; set; }

        [Display(Name = "Tipo")]
        public string Tipo { get; set; }

        [Display(Name ="Latitud")]
        public double Latitud { get; set; }

        [Display(Name ="Longitud")]
        public double Longitud { get; set; }
    }
}
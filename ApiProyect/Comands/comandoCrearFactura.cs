using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class comandoCrearFactura
    {

        public int NroFactura { get; set; }
        public string TipoFactura { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdFormaPago { get; set; }

    }
}

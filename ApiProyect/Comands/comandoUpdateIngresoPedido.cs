using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class comandoUpdateIngresoPedido
    {

        public int IdIngresoPedido { get; set; }
        public int IdProveedor { get; set; }
        public int IdEmpleado { get; set; }
        public int NroFacturaPedido { get; set; }
        public string TipoFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int NroOrdenCompra { get; set; }


    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class comandoCrearIngresoPedido
    {

        public int IdProveedor { get; set; }
        public int IdEmpleado { get; set; }
        public int NroRemitoPedido { get; set; }
        public string TipoFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int NroOrdenCompra { get; set; }
                public int Flag { get; set; }



    }
}
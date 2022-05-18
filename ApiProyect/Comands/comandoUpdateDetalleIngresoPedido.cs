using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class ComandoUpdateDetalleIngresoPedido
    {
        public int IdDetalleIngresoPedido { get; set; }
        public int IdIngresoPedido { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int IdArticulo { get; set; }
                public int Flag { get; set; }



    }
}
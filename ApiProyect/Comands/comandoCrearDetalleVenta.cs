using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class ComandoCrearDetalleVenta
    {

        public int IdVenta { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }


    }
}
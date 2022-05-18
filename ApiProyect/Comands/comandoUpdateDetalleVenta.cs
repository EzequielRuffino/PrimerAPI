using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class ComandoUpdateDetalleVenta
    {

        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }
                public int Flag { get; set; }



    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class DetalleVentum
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public int PrecioUnitario { get; set; }
                public int Flag { get; set; }


        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual Ventum IdVentaNavigation { get; set; }
    }
}

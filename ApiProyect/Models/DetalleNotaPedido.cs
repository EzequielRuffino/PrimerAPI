using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class DetalleNotaPedido
    {
        public int NroDetalleOrdenCompra { get; set; }
        public int NroOrdenCompra { get; set; }
        public int Cantidad { get; set; }
        public int IdArticulo { get; set; }
        public int Flag { get; set; }


        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual NotaPedido NroOrdenCompraNavigation { get; set; }
    }
}

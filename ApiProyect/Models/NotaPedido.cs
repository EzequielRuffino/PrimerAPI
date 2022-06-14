using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class NotaPedido
    {
        public NotaPedido()
        {
            DetalleNotaPedidos = new HashSet<DetalleNotaPedido>();
            IngresoPedidoProveedors = new HashSet<IngresoPedidoProveedor>();
        }

        public int IdOrdenCompra { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdEmpleado { get; set; }
        public int Flag { get; set; }


        public virtual Usuario IdEmpleadoNavigation { get; set; }
        public virtual ICollection<DetalleNotaPedido> DetalleNotaPedidos { get; set; }
        public virtual ICollection<IngresoPedidoProveedor> IngresoPedidoProveedors { get; set; }
    }
}

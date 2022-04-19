using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            IngresoPedidoProveedors = new HashSet<IngresoPedidoProveedor>();
            NotaPedidos = new HashSet<NotaPedido>();
            Venta = new HashSet<Ventum>();
        }

        public int Legajo { get; set; }
        public string NombreCompleto { get; set; }
        public int Documento { get; set; }
        public int CodBarrio { get; set; }
        public long Telefono { get; set; }
        public int IdEstadoArticulo { get; set; }//ver si hace falta

        public virtual Barrio CodBarrioNavigation { get; set; }
        public virtual EstadoArticulo IdEstadoArticuloNavigation { get; set; }
        public virtual ICollection<IngresoPedidoProveedor> IngresoPedidoProveedors { get; set; }
        public virtual ICollection<NotaPedido> NotaPedidos { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Devolucions = new HashSet<Devolucion>();
            IngresoPedidoProveedors = new HashSet<IngresoPedidoProveedor>();
            NotaPedidos = new HashSet<NotaPedido>();
            Venta = new HashSet<Ventum>();
        }

        public int Legajo { get; set; }
        public string NombreCompleto { get; set; }
        public int Documento { get; set; }
        public int CodBarrio { get; set; }
        public long Telefono { get; set; }
        public int IdTipoRol { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int Flag { get; set; }

        public virtual Barrio CodBarrioNavigation { get; set; }
        public virtual TipoRol IdTipoRolNavigation { get; set; }
        public virtual ICollection<Devolucion> Devolucions { get; set; }
        public virtual ICollection<IngresoPedidoProveedor> IngresoPedidoProveedors { get; set; }
        public virtual ICollection<NotaPedido> NotaPedidos { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}

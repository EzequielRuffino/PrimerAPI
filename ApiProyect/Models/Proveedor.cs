using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            IngresoPedidoProveedors = new HashSet<IngresoPedidoProveedor>();
        }

        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public int Documento { get; set; }
        public string Direccion { get; set; }//esta mal es un string
        public int? CodBarrio { get; set; }
        public int Telefono { get; set; }
        public int Flag { get; set; }


        public virtual Barrio CodBarrioNavigation { get; set; }
        public virtual ICollection<IngresoPedidoProveedor> IngresoPedidoProveedors { get; set; }
    }
}

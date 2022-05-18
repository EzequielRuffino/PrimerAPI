using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            DetalleDevolucion = new HashSet<DetalleDevolucion>();
            DetalleIngresoPedidos = new HashSet<DetalleIngresoPedido>();
            DetalleNotaPedidos = new HashSet<DetalleNotaPedido>();
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoArticulo { get; set; }
        public int PrecioVenta { get; set; }
        public int IdTalle { get; set; }
        public int IdMarca { get; set; }
        public int Cantidad { get; set; }
        public DateTime? FechaModificicacion { get; set; }
        public int IdEstadoArticulo { get; set; }
        public int Flag { get; set; }


        public virtual EstadoArticulo IdEstadoArticuloNavigation { get; set; }
        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual TalleArticulo IdTalleNavigation { get; set; }
        public virtual TipoArticulo IdTipoArticuloNavigation { get; set; }
        public virtual ICollection<DetalleIngresoPedido> DetalleIngresoPedidos { get; set; }
        public virtual ICollection<DetalleNotaPedido> DetalleNotaPedidos { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<DetalleDevolucion> DetalleDevolucion { get; set; }

    }
}

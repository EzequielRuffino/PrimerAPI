using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Ventum
    {
        public Ventum()
        {
            Devolucions = new HashSet<Devolucion>();
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int IdVenta { get; set; }
        public int NroFactura { get; set; }
        public string TipoFactura { get; set; }
        public DateTime FechaVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdEmpleado { get; set; }
        public int IdFormaPago { get; set; }
        public int Flag { get; set; }


        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Usuario IdEmpleadoNavigation { get; set; }
        public virtual FormaPago IdFormaPagoNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
       public virtual ICollection<Devolucion> Devolucions { get; set; }

    }
}

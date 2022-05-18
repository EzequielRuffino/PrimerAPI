using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Devolucion
    {
        public Devolucion()
        {
            DetalleDevolucion = new HashSet<DetalleDevolucion>();
        }

        public int IdDevolucion { get; set; }
        public int NroDevolucion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public int IdVenta { get; set; }
        public int IdEmpleado { get; set; }
        public int Flag { get; set; }


        public virtual Ventum IdVentaNavigation { get; set; }
        public virtual Usuario IdEmpleadoNavigation { get; set; }
        
        public virtual ICollection<DetalleDevolucion> DetalleDevolucion { get; set; }
    }
}
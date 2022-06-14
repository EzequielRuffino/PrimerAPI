using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class DetalleDevolucion
    {
        public int IdDetalleDevolucion { get; set; }
        public int IdArticulo { get; set; }
        public int IdDevolucion { get;set; }
        public int IdMotivo { get; set; }
        public int Cantidad { get; set; }
        public int Flag { get; set; }


        public virtual Articulo IdArticuloNavigation { get; set; }
        public virtual MotivoDevolucion IdMotivoNavigation { get; set; }
        public virtual Devolucion IdDevolucionNavigation { get; set; }
        
       // public virtual Devolucion DevolucionsNavigation { get; set; }

    }
}

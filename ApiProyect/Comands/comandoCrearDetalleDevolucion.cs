using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class comandoCrearDetalleDevolucion
    {

        public int IdDevolucion { get;set; }
        public int IdArticulo { get; set; }
        public int IdMotivo { get; set; }
        public int Cantidad { get; set; }
        public int Flag { get; set; }

    }
}
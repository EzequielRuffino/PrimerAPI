using System;

namespace ApiProyect.Comands
{

    public class comandoUpdateNotaPedido{
        public int IdOrdenCompra { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public int IdEmpleado { get; set; }
                public int Flag { get; set; }


    }

}
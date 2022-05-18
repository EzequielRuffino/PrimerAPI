using System;

namespace ApiProyect.Comands
{

    public class comandoUpdateDetalleNotaPedido
    {

        public int NroDetalleOrdenCompra { get; set; }
        public int NroOrdenCompra { get; set; }
        public int Cantidad { get; set; }
        public int IdArticulo { get; set; }
                public int Flag { get; set; }


    }

}
using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models.DTO
{
    public  class DTOListadoCompras
    {



        public int IdOrdenCompra { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string NombreCompleto { get; set; }
        public int Flag { get; set; }
        public string NombreArticulo { get; set; }
        public int Cantidad { get; set; }

                public class x{
       public List<DTOListadoCompras> NombreArticulo{get;set;}
        }


    }
}
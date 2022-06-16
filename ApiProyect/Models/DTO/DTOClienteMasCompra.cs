using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models.DTO
{
    public  class DTOClienteMasCompra
    {



        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string NombreCliente { get; set; }
        public int Cantidad { get; set; }


    }
}
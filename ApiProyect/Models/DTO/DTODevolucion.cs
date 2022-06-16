using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models.DTO
{
    public  class DTODevolucion
    {



        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public string NombreCliente { get; set; }
        public string NombreCompleto { get; set; }
        public string Descripcion { get; set; }
        public string NombreArticulo { get; set; }
        public int IdDevolucion { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public string Descripcion2 { get; set; }
        public int Cantidad { get; set; }


    }
}
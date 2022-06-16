using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models.DTO
{
    public  class DTOPagoProveedor
    {



        public int IdIngresoPedido { get; set; }
        public string RazonSocial { get; set; }
        public string NombreCompleto { get; set; }
        public int NroRemitoPedido { get; set; }
        public string Pago { get; set; } 
        public DateTime Fecha { get; set; }
        public int NroOrdenCompra { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string NombreArticulo { get; set; }
        //public int Flag { get; set; }



    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models.DTO
{
    public  class DTOListaClientes
    {



        public string NombreCliente { get; set; }
        public int Documento { get; set; }
        public string Direccion { get; set; }//no es int es string
        public string nombreBarrio { get; set; }
        public int Telefono { get; set; }


        public class x{
       public List<DTOListaClientes> NomBarrios{get;set;}
        }
    }
}
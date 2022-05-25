using System;

namespace ApiProyect.Comands
{

    public class comandoCrearProveedor
    {
     
        public string RazonSocial { get; set; }
        public int Documento { get; set; }
        public string Direccion { get; set; }//esta mal es un string
        public int? CodBarrio { get; set; }
        public int Telefono { get; set; }
        public int Flag { get; set; }


    }

}
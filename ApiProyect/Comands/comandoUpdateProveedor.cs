using System;

namespace ApiProyect.Comands
{

    public class comandoUpdateProveedor
    {
     
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public int Documento { get; set; }
        public int Direccion { get; set; }//esta mal es un string
        public int? CodBarrio { get; set; }
        public int Telefono { get; set; }
        public int IdEstadoArticulo { get; set; }

    }

}
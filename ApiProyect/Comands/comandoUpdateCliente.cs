using System;

namespace ApiProyect.Comands
{

    public class comandoUpdateCliente
    {
     
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int Documento { get; set; }
        public string Direccion { get; set; }
        public int CodBarrio { get; set; }
        public int Telefono { get; set; }
        public int Flag { get; set; }

    }

}
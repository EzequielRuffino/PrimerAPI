using System;

namespace ApiProyect.Comands
{

    public class comandoUpdateEmpleado
    {
     
        public int Legajo { get; set; }
        public string NombreCompleto { get; set; }
        public int Documento { get; set; }
        public int CodBarrio { get; set; }
        public long Telefono { get; set; }
        public int IdEstadoArticulo { get; set; }

    }

}
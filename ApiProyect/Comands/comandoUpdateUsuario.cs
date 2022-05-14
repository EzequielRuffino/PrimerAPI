using System;

namespace ApiProyect.Comands
{

    public class comandoUpdateUsuario
    
    {
     
        public int Legajo { get; set; }
        public string NombreCompleto { get; set; }
        public int Documento { get; set; }
        public int CodBarrio { get; set; }
        public long Telefono { get; set; }
        public int IdTipoRol{ get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public int Flag { get; set; }

    }

}
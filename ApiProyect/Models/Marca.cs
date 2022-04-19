using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class TalleArticulo
    {
        public TalleArticulo()
        {
            Articulos = new HashSet<Articulo>();
        }

        public int IdTalle { get; set; }
        public string NombreTalle { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
    }
}

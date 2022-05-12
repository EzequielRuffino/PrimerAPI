using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class TipoRol
    {
        public TipoRol()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoRol { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}

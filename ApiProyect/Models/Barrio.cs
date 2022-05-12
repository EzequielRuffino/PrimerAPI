using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Barrio
    {
        public Barrio()
        {
            Clientes = new HashSet<Cliente>();
            Usuarios = new HashSet<Usuario>();
            Proveedors = new HashSet<Proveedor>();
        }

        public int CodBarrio { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Proveedor> Proveedors { get; set; }
    }
}

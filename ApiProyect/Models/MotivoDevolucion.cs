using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class MotivoDevolucion
    {
        public MotivoDevolucion()
        {
            DetalleDevolucion = new HashSet<DetalleDevolucion>();
            //Usuarios = new HashSet<Usuario>();
            //Proveedors = new HashSet<Proveedor>();
        }

        public int IdMotivo { get; set; }
        public string Descripcion { get; set; }

          public virtual ICollection<DetalleDevolucion> DetalleDevolucion { get; set; }
      //  public virtual ICollection<Usuario> Usuarios { get; set; }
      //  public virtual ICollection<Proveedor> Proveedors { get; set; }
    }
}


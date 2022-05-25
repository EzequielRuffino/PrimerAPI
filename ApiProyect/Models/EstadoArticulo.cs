using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class EstadoArticulo
    {
        public EstadoArticulo()
        {
            Articulos = new HashSet<Articulo>();
           // Empleados = new HashSet<Empleado>();
           // Proveedors = new HashSet<Proveedor>();
        }

        public int IdEstadoArticulo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Articulo> Articulos { get; set; }
        
       // public virtual ICollection<Empleado> Empleados { get; set; }
       // public virtual ICollection<Proveedor> Proveedors { get; set; }
    }
}

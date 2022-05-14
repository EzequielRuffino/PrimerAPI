using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Venta = new HashSet<Ventum>();
        }

        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int Documento { get; set; }
        public string Direccion { get; set; }//no es int es string
        public int CodBarrio { get; set; }
        public int Telefono { get; set; }
        public int Flag { get; set; }


        public virtual Barrio CodBarrioNavigation { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}

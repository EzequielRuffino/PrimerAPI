using System;
using System.Collections.Generic;

#nullable disable

namespace ApiProyect.Models
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            Venta = new HashSet<Ventum>();
        }

        public int IdFormaPago { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Ventum> Venta { get; set; }
    }
}

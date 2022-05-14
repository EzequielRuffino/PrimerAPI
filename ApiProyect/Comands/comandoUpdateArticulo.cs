using System;
namespace ApiProyect.Comands
{
    public class comandoUpdateArticulo
    {
        public int IdArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public int IdTipoArticulo { get; set; }
        public int PrecioVenta { get; set; }
        public int IdTalle { get; set; }
        public int IdMarca { get; set; }
        public int Cantidad { get; set; }
        public DateTime? FechaModificicacion { get; set; }
        public int IdEstadoArticulo { get; set; }
        public int Flag { get; set; }

    }
}
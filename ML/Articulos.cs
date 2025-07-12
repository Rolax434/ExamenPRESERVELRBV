using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Articulos
    {
        public int IdArticulo { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
        public byte[]? Imagen { get; set; }
        public int Stock { get; set; }
        public int Cantidad { get; set; }
        public DateTime? FechaCompra { get; set; }
        public DateOnly? FechaRelacion { get; set; }
    }
}

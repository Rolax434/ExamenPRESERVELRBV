using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DL.Models;

[Index("Codigo", Name = "UQ__Articulo__06370DAC484244E4", IsUnique = true)]
public partial class Articulo
{
    [Key]
    public int IdArticulo { get; set; }

    [StringLength(50)]
    public string Codigo { get; set; } = null!;

    [StringLength(255)]
    public string Descripcion { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Precio { get; set; }

    public byte[]? Imagen { get; set; }

    public int Stock { get; set; }

    [InverseProperty("IdArticuloNavigation")]
    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; } = new List<ClienteArticulo>();

    [InverseProperty("IdArticuloNavigation")]
    public virtual ICollection<TiendaArticulo> TiendaArticulos { get; set; } = new List<TiendaArticulo>();
}

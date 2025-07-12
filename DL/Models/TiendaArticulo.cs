using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DL.Models;

[PrimaryKey("IdTienda", "IdArticulo")]
[Table("TiendaArticulo")]
public partial class TiendaArticulo
{
    [Key]
    public int IdTienda { get; set; }

    [Key]
    public int IdArticulo { get; set; }

    public DateOnly Fecha { get; set; }

    [ForeignKey("IdArticulo")]
    [InverseProperty("TiendaArticulos")]
    public virtual Articulo IdArticuloNavigation { get; set; } = null!;

    [ForeignKey("IdTienda")]
    [InverseProperty("TiendaArticulos")]
    public virtual Tiendum IdTiendaNavigation { get; set; } = null!;
}

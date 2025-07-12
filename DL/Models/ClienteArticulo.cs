using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DL.Models;

[Table("ClienteArticulo")]
public partial class ClienteArticulo
{
    [Key]
    public int IdCompra { get; set; }

    public int IdCliente { get; set; }

    public int IdArticulo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Fecha { get; set; }

    [ForeignKey("IdArticulo")]
    [InverseProperty("ClienteArticulos")]
    public virtual Articulo IdArticuloNavigation { get; set; } = null!;

    [ForeignKey("IdCliente")]
    [InverseProperty("ClienteArticulos")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}

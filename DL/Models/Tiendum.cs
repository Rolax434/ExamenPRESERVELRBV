using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DL.Models;

public partial class Tiendum
{
    [Key]
    public int IdTienda { get; set; }

    [StringLength(100)]
    public string Sucursal { get; set; } = null!;

    [StringLength(100)]
    public string? Calle { get; set; }

    [StringLength(10)]
    public string? NumeroExterior { get; set; }

    [StringLength(10)]
    public string? NumeroInterior { get; set; }

    [StringLength(100)]
    public string? Colonia { get; set; }

    [StringLength(100)]
    public string? Municipio { get; set; }

    [StringLength(100)]
    public string? Estado { get; set; }

    [StringLength(10)]
    public string? CodigoPostal { get; set; }

    [InverseProperty("IdTiendaNavigation")]
    public virtual ICollection<TiendaArticulo> TiendaArticulos { get; set; } = new List<TiendaArticulo>();
}

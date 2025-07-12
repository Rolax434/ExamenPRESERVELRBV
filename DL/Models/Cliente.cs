using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DL.Models;

public partial class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    public string ApellidoPaterno { get; set; } = null!;

    [StringLength(100)]
    public string? ApellidoMaterno { get; set; }

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

    [StringLength(100)]
    public string Contraseña { get; set; } = null!;

    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; } = new List<ClienteArticulo>();
}

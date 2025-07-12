using System.ComponentModel.DataAnnotations;

namespace ML
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Calle { get; set; }
        public string? NumeroExterior { get; set; }
        public string? NumeroInterior { get; set; }
        public string? Colonia { get; set; }
        public string? Municipio { get; set; }
        public string? Estado { get; set; }
        public string? CodigoPostal { get; set; }
        public string Contrasenia { get; set; }
        public string UserName { get; set; }

    }
}

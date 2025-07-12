using DL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BL
{
    public class Cliente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var clientes = context.Clientes.ToList();

                    if (clientes.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var DBcliente in clientes)
                        {
                            ML.Cliente cliente = new ML.Cliente();
                            cliente.IdCliente = DBcliente.IdCliente;
                            cliente.Nombre = DBcliente.Nombre;
                            cliente.ApellidoPaterno = DBcliente.ApellidoPaterno;
                            cliente.ApellidoMaterno = DBcliente.ApellidoMaterno;
                            cliente.Calle = DBcliente.Calle;
                            cliente.NumeroExterior = DBcliente.NumeroExterior;
                            cliente.NumeroInterior = DBcliente.NumeroInterior;
                            cliente.Colonia = DBcliente.Colonia;
                            cliente.Municipio = DBcliente.Municipio;
                            cliente.Estado = DBcliente.Estado;
                            cliente.CodigoPostal = DBcliente.CodigoPostal;
                            cliente.UserName = DBcliente.UserName;
                            cliente.Contrasenia = DBcliente.Contraseña;

                            result.Objects.Add(cliente);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se han encontrado clientes registrados";
                    }
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.Correct = false;
                result.Ex = e;
            }

            return result;
        }

        public static ML.Result GetByID(int idCliente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var DBcliente = context.Clientes.FirstOrDefault(c => c.IdCliente == idCliente);

                    if (DBcliente != null)
                    {
                        ML.Cliente cliente = new ML.Cliente();
                        cliente.IdCliente = DBcliente.IdCliente;
                        cliente.Nombre = DBcliente.Nombre;
                        cliente.ApellidoPaterno = DBcliente.ApellidoPaterno;
                        cliente.ApellidoMaterno = DBcliente.ApellidoMaterno;
                        cliente.Calle = DBcliente.Calle;
                        cliente.NumeroExterior = DBcliente.NumeroExterior;
                        cliente.NumeroInterior = DBcliente.NumeroInterior;
                        cliente.Colonia = DBcliente.Colonia;
                        cliente.Municipio = DBcliente.Municipio;
                        cliente.Estado = DBcliente.Estado;
                        cliente.CodigoPostal = DBcliente.CodigoPostal;
                        cliente.UserName = DBcliente.UserName;
                        cliente.Contrasenia = DBcliente.Contraseña;

                        result.Object = cliente;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = $"No se encontró ningun cliente con ID {idCliente}.";
                    }
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.Correct = false;
                result.Ex = e;
            }

            return result;
        }

        public static ML.Result Add(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    DL.Models.Cliente nuevoCliente = new DL.Models.Cliente
                    {
                        Nombre = cliente.Nombre,
                        ApellidoPaterno = cliente.ApellidoPaterno,
                        ApellidoMaterno = cliente.ApellidoMaterno,
                        Calle = cliente.Calle,
                        NumeroExterior = cliente.NumeroExterior,
                        NumeroInterior = cliente.NumeroInterior,
                        Colonia = cliente.Colonia,
                        Municipio = cliente.Municipio,
                        Estado = cliente.Estado,
                        CodigoPostal = cliente.CodigoPostal,
                        UserName = cliente.UserName,
                        Contraseña = cliente.Contrasenia
                    };

                    context.Clientes.Add(nuevoCliente);
                    context.SaveChanges();

                    result.Correct = true;
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        public static ML.Result Update(ML.Cliente cliente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var DBcliente = context.Clientes.FirstOrDefault(c => c.IdCliente == cliente.IdCliente);

                    if (DBcliente != null)
                    {
                        DBcliente.Nombre = cliente.Nombre;
                        DBcliente.ApellidoPaterno = cliente.ApellidoPaterno;
                        DBcliente.ApellidoMaterno = cliente.ApellidoMaterno;
                        DBcliente.Calle = cliente.Calle;
                        DBcliente.NumeroExterior = cliente.NumeroExterior;
                        DBcliente.NumeroInterior = cliente.NumeroInterior;
                        DBcliente.Colonia = cliente.Colonia;
                        DBcliente.Municipio = cliente.Municipio;
                        DBcliente.Estado = cliente.Estado;
                        DBcliente.CodigoPostal = cliente.CodigoPostal;
                        DBcliente.UserName = cliente.UserName;
                        DBcliente.Contraseña = cliente.Contrasenia;

                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el cliente a actualizar.";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        public static ML.Result Delete(int idCliente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    using (var transaccion = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var cliente = context.Clientes.FirstOrDefault(c => c.IdCliente == idCliente);

                            if (cliente != null)
                            {
                                var compras = context.ClienteArticulos.Where(ca => ca.IdCliente == cliente.IdCliente).ToList();
                                foreach (var compra in compras)
                                {
                                    context.ClienteArticulos.Remove(compra);
                                }
                                context.Clientes.Remove(cliente);
                                context.SaveChanges();
                                transaccion.Commit();
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontró el cliente a eliminar.";
                            }
                        }
                        catch (Exception etrans)
                        {
                            transaccion.Rollback();
                            result.Correct = false;
                            result.ErrorMessage = etrans.Message;
                            result.Ex = etrans;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        public static ML.Result AddCompra(int idCliente, int idArticulo, int cantidad)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    using(var transaccion = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var DBarticulo = context.Articulos.FirstOrDefault(a => a.IdArticulo == idArticulo);

                            if (DBarticulo != null && DBarticulo.Stock >= cantidad)
                            {
                                DL.Models.ClienteArticulo nuevaCompra = new DL.Models.ClienteArticulo
                                {
                                    IdCliente = idCliente,
                                    IdArticulo = idArticulo
                                };
                                DBarticulo.Stock = DBarticulo.Stock - cantidad;

                                context.ClienteArticulos.Add(nuevaCompra);
                                context.SaveChanges();
                                transaccion.Commit();
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontró el articulo a actualizar o sin stock disponible.";
                            }
                        }
                        catch (Exception etrans)
                        {
                            transaccion.Rollback();
                            result.Correct = false;
                            result.Ex = etrans;
                            result.ErrorMessage = etrans.Message;
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
                result.Ex = e;
            }

            return result;
        }

        public static ML.Result GetHistorialCompras(int IdCliente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var compras = context.ClienteArticulos.Where(ca => ca.IdCliente == IdCliente).Include(ca => ca.IdArticuloNavigation).ToList();
                    if (compras.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var DBcompra in compras)
                        {
                            ML.Articulos compra = new ML.Articulos();
                            compra.Descripcion = DBcompra.IdArticuloNavigation.Descripcion;
                            compra.Imagen = DBcompra.IdArticuloNavigation.Imagen;
                            compra.Precio = DBcompra.IdArticuloNavigation.Precio;
                            compra.FechaCompra = DBcompra.Fecha;

                            result.Objects.Add(compra);
                        }

                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Actualmente no hay compras registradas en esta cuenta";
                    }
                    
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
                result.Correct = false;
                result.Ex = e;
            }

            return result;
        }
    }
}

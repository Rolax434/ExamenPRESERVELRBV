using DL.Models;
using Microsoft.EntityFrameworkCore;
using ML;

namespace BL
{
    public class Tienda
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var tiendas = context.Tienda.ToList();

                    if (tiendas.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var DBtienda in tiendas)
                        {
                            ML.Tienda tienda = new ML.Tienda();
                            tienda.IdTienda = DBtienda.IdTienda;
                            tienda.Sucursal = DBtienda.Sucursal;
                            tienda.Calle = DBtienda.Calle;
                            tienda.NumeroExterior = DBtienda.NumeroExterior;
                            tienda.NumeroInterior = DBtienda.NumeroInterior;
                            tienda.Colonia = DBtienda.Colonia;
                            tienda.Municipio = DBtienda.Municipio;
                            tienda.Estado = DBtienda.Estado;
                            tienda.CodigoPostal = DBtienda.CodigoPostal;

                            result.Objects.Add(tienda);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Actualmente no hay tiendas registradas";
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

        public static ML.Result GetByID(int idTienda)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var DBtienda = context.Tienda.FirstOrDefault(t => t.IdTienda == idTienda);

                    if (DBtienda != null)
                    {
                        ML.Tienda tienda = new ML.Tienda();
                        tienda.IdTienda = DBtienda.IdTienda;
                        tienda.Sucursal = DBtienda.Sucursal;
                        tienda.Calle = DBtienda.Calle;
                        tienda.NumeroExterior = DBtienda.NumeroExterior;
                        tienda.NumeroInterior = DBtienda.NumeroInterior;
                        tienda.Colonia = DBtienda.Colonia;
                        tienda.Municipio = DBtienda.Municipio;
                        tienda.Estado = DBtienda.Estado;
                        tienda.CodigoPostal = DBtienda.CodigoPostal;

                        result.Object = tienda;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = $"No se encontró ninguna sucursal con ID {idTienda}.";
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

        public static ML.Result Add(ML.Tienda tienda)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    DL.Models.Tiendum nuevaTienda = new DL.Models.Tiendum
                    {
                        Sucursal = tienda.Sucursal,
                        Calle = tienda.Calle,
                        NumeroExterior = tienda.NumeroExterior,
                        NumeroInterior = tienda.NumeroInterior,
                        Colonia = tienda.Colonia,
                        Municipio = tienda.Municipio,
                        Estado = tienda.Estado,
                        CodigoPostal = tienda.CodigoPostal
                    };

                    context.Tienda.Add(nuevaTienda);
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

        public static ML.Result Update(ML.Tienda tienda)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var DBtienda = context.Tienda.FirstOrDefault(t => t.IdTienda == tienda.IdTienda);

                    if (DBtienda != null)
                    {
                        DBtienda.Sucursal = tienda.Sucursal;
                        DBtienda.Calle = tienda.Calle;
                        DBtienda.NumeroExterior = tienda.NumeroExterior;
                        DBtienda.NumeroInterior = tienda.NumeroInterior;
                        DBtienda.Colonia = tienda.Colonia;
                        DBtienda.Municipio = tienda.Municipio;
                        DBtienda.Estado = tienda.Estado;
                        DBtienda.CodigoPostal = tienda.CodigoPostal;

                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró la tienda a actualizar.";
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

        public static ML.Result Delete(int idTienda)
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
                            var tienda = context.Tienda.FirstOrDefault(t => t.IdTienda == idTienda);

                            if (tienda != null)
                            {
                                var articulosRelacionados = context.TiendaArticulos.Where(ta => ta.IdTienda == tienda.IdTienda).ToList();
                                foreach (var tiendaRelacionada in articulosRelacionados)
                                {
                                    context.TiendaArticulos.Remove(tiendaRelacionada);
                                }
                                context.Tienda.Remove(tienda);
                                context.SaveChanges();
                                transaccion.Commit();
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontró la tienda a eliminar.";
                            }
                        } catch (Exception etrans)
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

        public static ML.Result AddArticulo(int idTienda, int idArticulo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    DL.Models.TiendaArticulo nuevoArticulo = new DL.Models.TiendaArticulo
                    {
                        IdTienda = idTienda,
                        IdArticulo = idArticulo
                    };

                    context.TiendaArticulos.Add(nuevoArticulo);
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

        public static ML.Result GetArticulosRelacionados(int IdTienda)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var articulosRelacionados = context.TiendaArticulos.Where(ta => ta.IdTienda == IdTienda).Include(ta => ta.IdArticuloNavigation).ToList();

                    if (articulosRelacionados.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var DBarticulo in articulosRelacionados)
                        {
                            ML.Articulos articuloRel = new ML.Articulos();
                            articuloRel.IdArticulo = DBarticulo.IdArticuloNavigation.IdArticulo;
                            articuloRel.Codigo = DBarticulo.IdArticuloNavigation.Codigo;
                            articuloRel.Descripcion = DBarticulo.IdArticuloNavigation.Descripcion;
                            articuloRel.Imagen = DBarticulo.IdArticuloNavigation.Imagen;
                            articuloRel.Precio = DBarticulo.IdArticuloNavigation.Precio;
                            articuloRel.Stock = DBarticulo.IdArticuloNavigation.Stock;
                            articuloRel.FechaRelacion = DBarticulo.Fecha;

                            result.Objects.Add(articuloRel);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Esta tienda actualmente no contiene ningun articulo relacionado";
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

        public static ML.Result GetArticulosDisponibles(int IdTienda)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var idsRelacionados = context.TiendaArticulos
                        .Where(ta => ta.IdTienda == IdTienda)
                        .Select(ta => ta.IdArticulo)
                        .ToList();

                    var articulosDisponibles = context.Articulos
                        .AsEnumerable()
                        .Where(a => !idsRelacionados.Contains(a.IdArticulo))
                        .ToList();

                    if (articulosDisponibles.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var DBarticulo in articulosDisponibles)
                        {
                            ML.Articulos articuloDis = new ML.Articulos();
                            articuloDis.IdArticulo = DBarticulo.IdArticulo;
                            articuloDis.Codigo = DBarticulo.Codigo;
                            articuloDis.Descripcion = DBarticulo.Descripcion;
                            articuloDis.Imagen = DBarticulo.Imagen;
                            articuloDis.Precio = DBarticulo.Precio;
                            articuloDis.Stock = DBarticulo.Stock;

                            result.Objects.Add(articuloDis);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tienda seleccionada ya cuenta con todos los articulos en disponibilidad o no hay articulos registrados";
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

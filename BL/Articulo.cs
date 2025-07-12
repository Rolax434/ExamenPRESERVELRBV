using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BL
{
    public class Articulo
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var articulos = context.Articulos.ToList();

                    if (articulos.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var DBarticulo in articulos)
                        {
                            ML.Articulos articulo = new ML.Articulos();
                            articulo.IdArticulo = DBarticulo.IdArticulo;
                            articulo.Codigo = DBarticulo.Codigo;
                            articulo.Descripcion = DBarticulo.Descripcion;
                            articulo.Precio = DBarticulo.Precio;
                            articulo.Imagen = DBarticulo.Imagen;
                            articulo.Stock = DBarticulo.Stock;

                            result.Objects.Add(articulo);
                        }

                        result.Correct = true;
                    } else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Actualmente no hay articulos registrados";
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

        public static ML.Result GetByID(int idArticulo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var DBarticulo = context.Articulos.FirstOrDefault(a => a.IdArticulo == idArticulo);

                    if (DBarticulo != null)
                    {
                        ML.Articulos articulo = new ML.Articulos();
                        articulo.IdArticulo = DBarticulo.IdArticulo;
                        articulo.Codigo = DBarticulo.Codigo;
                        articulo.Descripcion = DBarticulo.Descripcion;
                        articulo.Precio = DBarticulo.Precio;
                        articulo.Imagen = DBarticulo.Imagen;
                        articulo.Stock = DBarticulo.Stock;

                        result.Object = articulo;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = $"No se encontró ningun articulo con ID {idArticulo}.";
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

        public static ML.Result Add(ML.Articulos articulo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    DL.Models.Articulo nuevoArticulo = new DL.Models.Articulo
                    {
                        Codigo = articulo.Codigo,
                        Descripcion = articulo.Descripcion,
                        Precio = articulo.Precio,
                        Imagen = articulo.Imagen,
                        Stock = articulo.Stock
                    };

                    context.Articulos.Add(nuevoArticulo);


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

        public static ML.Result Update(ML.Articulos articulo)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.Context.ExamenContext context = new DL.Context.ExamenContext())
                {
                    var DBarticulo = context.Articulos.FirstOrDefault(a => a.IdArticulo == articulo.IdArticulo);

                    if (DBarticulo != null)
                    {
                        DBarticulo.Codigo = articulo.Codigo;
                        DBarticulo.Descripcion = articulo.Descripcion;
                        DBarticulo.Precio = articulo.Precio;
                        DBarticulo.Imagen = articulo.Imagen;
                        DBarticulo.Stock = articulo.Stock;

                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontró el articulo a actualizar.";
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

        public static ML.Result Delete(int idArticulo)
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
                            var articulo = context.Articulos.FirstOrDefault(a => a.IdArticulo == idArticulo);

                            if (articulo != null)
                            {
                                var compras = context.ClienteArticulos.Where(ca => ca.IdArticulo == articulo.IdArticulo).ToList();
                                foreach (var compra in compras)
                                {
                                    context.ClienteArticulos.Remove(compra);
                                }

                                var articulosRelacionados = context.TiendaArticulos.Where(ta => ta.IdArticulo == articulo.IdArticulo).ToList();
                                foreach (var tiendaRelacionada in articulosRelacionados)
                                {
                                    context.TiendaArticulos.Remove(tiendaRelacionada);
                                }
                                context.Articulos.Remove(articulo);
                                context.SaveChanges();
                                transaccion.Commit();
                                result.Correct = true;
                            }
                            else
                            {
                                result.Correct = false;
                                result.ErrorMessage = "No se encontró el articulo a eliminar.";
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
    }
}

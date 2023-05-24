using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Libro
    {
        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"LibroAdd '{libro.Portada}','{libro.Descripcion}','{libro.Publicacion}',{libro.IdAutor},{libro.IdEditorial}");
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el libro" + ex;
            }
            return result;
        }
        public static ML.Result GetAll(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    var queryEF = context.Libros.FromSqlRaw($"UsuarioGetAll '{libro.Nombre}','{libro.Portada}','{libro.Publicacion}'").ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();

                            libro.IdLibro = obj.IdLibro;
                            libro.Nombre = obj.Titulo;
                            libro.Portada = obj.Portada;
                            libro.Descripcion = obj.Descripcion;
                            libro.Publicacion = obj.Publicacion;

                            libro.Autor.IdAutor = obj.IdAutor;
                            libro.Autor.Nombre = obj.Autor;
                            libro.Editorial.IdEditorial = obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Editorial;

                            result.Objects.Add(libro);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el libro" + ex;
            }
            return result;
        }
        public static ML.Result LibroGetAllFecha(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    var queryEF = context.Libros.FromSqlRaw($"UsuarioGetAll '{libro.Nombre}','{libro.Publicacion}'").ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();

                            libro.IdLibro = obj.IdLibro;
                            libro.Nombre = obj.Titulo;
                            libro.Portada = obj.Portada;
                            libro.Descripcion = obj.Descripcion;
                            libro.Publicacion = obj.Publicacion;

                            libro.Autor.IdAutor = obj.IdAutor;
                            libro.Autor.Nombre = obj.Autor;
                            libro.Editorial.IdEditorial = obj.IdEditorial;
                            libro.Editorial.Nombre = obj.Editorial;

                            result.Objects.Add(libro);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el libro" + ex;
            }
            return result;
        }
        public static ML.Result DeleteByAutor(int IdAutor)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"DeleteByAutor {IdAutor}");
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el usuario" + ex;
            }
            return result;
        }
        public static ML.Result DeleteByEditorial(int IdEditorial)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"DeleteByEditorial {IdEditorial}");
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el usuario" + ex;
            }
            return result;
        }
    }
}
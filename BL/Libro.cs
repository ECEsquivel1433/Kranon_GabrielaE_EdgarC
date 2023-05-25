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
                    int queryEF = context.Database.ExecuteSqlRaw($"LibroAdd '{libro.Nombre}','{libro.Descripcion}','{libro.Publicacion}',{libro.Autor.IdAutor},{libro.Editorial.IdEditorial},'{libro.Imagen}'");
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
                    var queryEF = context.Libros.FromSqlRaw($"LibroGetAll '{libro.Autor.Nombre}','{libro.Portada}','{libro.Publicacion}', '{libro.Editorial.Nombre}'").ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            libro = new ML.Libro();
                            libro.Autor = new ML.Autor();
                            libro.Editorial = new ML.Editorial();

                            libro.IdLibro = obj.IdLibro;
                            
                            libro.Portada = obj.Portada;
                            libro.Descripcion = obj.Descripcion;
                            libro.Publicacion = obj.Publicacion;
                            libro.Imagen = obj.Imagen;

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
                           
                            libro.Portada = obj.Portada;
                            libro.Descripcion = obj.Descripcion;
                            libro.Publicacion = obj.Publicacion;
                            libro.Imagen = obj.Imagen;

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
        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    var row = context.Libros.FromSqlRaw($"LibroGetById {IdLibro}").AsEnumerable().FirstOrDefault();
                    if (row != null)
                    {
                        ML.Libro libro = new ML.Libro();
                        libro.Autor = new ML.Autor();
                        libro.Editorial = new ML.Editorial();

                        libro.IdLibro = row.IdLibro;

                        libro.Portada = row.Portada;
                        libro.Descripcion = row.Descripcion;
                        libro.Publicacion = row.Publicacion;
                        libro.Imagen = row.Imagen;

                        libro.Autor.IdAutor = row.IdAutor;
                        libro.Autor.Nombre = row.Autor;
                        libro.Editorial.IdEditorial = row.IdEditorial;
                        libro.Editorial.Nombre = row.Editorial;
                        result.Object = libro;
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    int queryEF = context.Database.ExecuteSqlRaw($"LibroDelete {IdLibro}");
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
    }
}
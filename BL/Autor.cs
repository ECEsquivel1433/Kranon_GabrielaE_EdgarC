using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            ML.Libro libro= new ML.Libro();
            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    var queryEF = context.Libros.FromSqlRaw($"AutorGetAll").ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            libro = new ML.Libro();
                            libro.Autor = new ML.Autor();

                            libro.Autor.IdAutor = obj.IdAutor;
                            libro.Autor.Nombre = obj.Autor;

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
    }
}

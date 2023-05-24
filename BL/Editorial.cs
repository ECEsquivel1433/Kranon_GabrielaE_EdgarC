using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Editorial
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            ML.Libro libro = new ML.Libro();
            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    var queryEF = context.Libros.FromSqlRaw($"EditorialGetAll").ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            libro = new ML.Libro();
                            libro.Editorial = new ML.Editorial();

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
    }
}

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
            
            try
            {
                using (DL.KranonGabrielaEEdgarCContext context = new DL.KranonGabrielaEEdgarCContext())
                {
                    var queryEF = context.Editorials.FromSqlRaw($"EditorialGetAll").ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            ML.Editorial editorial = new ML.Editorial();
                            editorial.IdEditorial = obj.IdEditorial;
                            editorial.Nombre = obj.NombreEditorial;

                            result.Objects.Add(editorial);
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

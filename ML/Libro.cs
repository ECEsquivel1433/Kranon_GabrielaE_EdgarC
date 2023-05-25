using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Libro
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; } = default!;
        public string Portada { get; set; } = default!;
        public string Descripcion { get; set; } = default!;
        public string Publicacion { get; set; } = default!;
        public string Imagen { get; set; } = default!;
        public List<object> Libros { get; set; } = default!;
        public ML.Editorial Editorial { get; set; } = default!;
        public ML.Autor Autor { get; set; } = default!; 
        public int IdAutor { get; set; }
        public int IdEditorial { get; set; }
        public int MyProperty { get; set; }
    }
}

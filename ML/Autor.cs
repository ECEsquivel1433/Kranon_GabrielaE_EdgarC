using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Nombre { get; set; } = default!;
        public string ApellidoPaterno { get; set; } = default!;
        public string ApellidoMaterno { get; set; } = default!;
        public string FechaNacimiento { get; set; } = default!;
        public string Direccion { get; set; } = default!;
    }
}

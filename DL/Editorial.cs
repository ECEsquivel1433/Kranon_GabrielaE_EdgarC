using System;
using System.Collections.Generic;

namespace DL;

public partial class Editorial
{
    public int IdEditorial { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}

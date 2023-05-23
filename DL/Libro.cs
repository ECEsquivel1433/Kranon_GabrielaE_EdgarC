using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Portada { get; set; }

    public string? Descripcion { get; set; }

    public string? Publicacion { get; set; }

    public int? IdAutor { get; set; }

    public int IdEditorial { get; set; }

    public string? Titulo { get; set; } = default!;

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }

    public string MyProperty { get; set; }
    public string Autor { get; set; }
    public string Editorial { get; set; }
}

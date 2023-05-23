using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public int IdLibro { get; set; }

    public string? Portada { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? Publicacion { get; set; }

    public int? IdAutor { get; set; }

    public int? IdEditorial { get; set; }

    public string? Titulo { get; set; }

    public virtual Autor? IdAutorNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }
}

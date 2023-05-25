using System;
using System.Collections.Generic;

namespace DL;

public partial class Libro
{
    public int IdLibro { get; set; } = default!;

    public string Portada { get; set; } = default!;

    public string Descripcion { get; set; } = default!;

    public string Publicacion { get; set; } = default!;

    public int IdAutor { get; set; }

    public int IdEditorial { get; set; }

    public string Imagen { get; set; } = default!;

    public virtual  Autor? IdAutorNavigation { get; set; }

    public virtual Editorial? IdEditorialNavigation { get; set; }
    public string Autor { get; set; } = default!;
    public string Editorial { get; set; } = default!;
}

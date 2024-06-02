using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriscilaZunigaAPIBookBites.Data.Models;

public partial class Pzcopium
{
    [Key]
    public int PzcopiaId { get; set; }

    public int Pzcantidad { get; set; }

    public bool Pzcolor { get; set; }

    public string Pzformato { get; set; } = null!;

    public DateOnly PzfechaCopia { get; set; }

    public int PzlibroId { get; set; }

    public virtual Pzlibro Pzlibro { get; set; } = null!;
}

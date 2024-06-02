using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PriscilaZunigaAPIBookBites.Data.Models;

public partial class Pzlibro
{
    [Key]
    public int PzlibroId { get; set; }

    public string Pztitulo { get; set; } = null!;

    public string Pzautor { get; set; } = null!;

    public int Pzvolumen { get; set; }

    public float Pzprecio { get; set; }

    public string Pznombre { get; set; } = null!;

    public virtual ICollection<Pzcopium> Pzcopia { get; set; } = new List<Pzcopium>();
}

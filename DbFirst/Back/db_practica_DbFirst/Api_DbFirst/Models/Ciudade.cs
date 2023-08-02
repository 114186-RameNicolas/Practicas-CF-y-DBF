using System;
using System.Collections.Generic;

namespace Api_DbFirst.Models;

public partial class Ciudade
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public virtual Sucursale? Sucursale { get; set; }
}

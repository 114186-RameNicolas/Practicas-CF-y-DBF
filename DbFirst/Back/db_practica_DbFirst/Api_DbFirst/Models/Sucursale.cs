using System;
using System.Collections.Generic;

namespace Api_DbFirst.Models;

public partial class Sucursale
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public Guid IdCiudad { get; set; }

    public Ciudade Ciudad { get; set; }

    public virtual Ciudade IdCiudadNavigation { get; set; } = null!;
}

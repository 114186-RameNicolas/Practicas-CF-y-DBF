using System;
using System.Collections.Generic;

namespace Api_DbFirst.Models;

public partial class Cargo
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public virtual Empleado? Empleado { get; set; }
}

using System;
using System.Collections.Generic;

namespace Api_DbFirst.Models;

public partial class Empleado
{
    public Guid Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public Guid IdCargo { get; set; }

    public Guid? IdSucursal { get; set; }

    public long? Dni { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public virtual Cargo IdCargoNavigation { get; set; } = null!;
}

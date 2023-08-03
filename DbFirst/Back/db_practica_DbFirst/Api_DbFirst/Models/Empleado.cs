using System;
using System.Collections.Generic;

namespace Api_DbFirst.Models;

public partial class Empleado
{
    public Guid Id { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public Guid IdCargo { get; set; }
    public Cargo Cargo { get; set; }
    public Guid? IdSucursal { get; set; }
    public Sucursale Sucursal { get; set; }
    public string Dni { get; set; }
    public DateTime FechaAlta { get; set; }
    public virtual Cargo IdCargoNavigation { get; set; } = null!;
}

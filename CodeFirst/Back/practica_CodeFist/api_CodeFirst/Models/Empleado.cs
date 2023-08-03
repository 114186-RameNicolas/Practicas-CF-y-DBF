using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Models
{
    public class Empleado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null;
        public string Apellido { get; set; } = null;

        [ForeignKey("IdCargo")]
        public Guid CargoId { get; set; }
        public Cargo Cargo { get; set; } = null;

        [ForeignKey("IdSucursal")]
        public Guid SucursalId { get; set; }
        public Sucursal Sucursal { get; set; } = null;

        public string DNI { get; set; }
        public DateTime FechaAlta { get; set; }

        [ForeignKey("IdJefe")]
        public Guid JefeId { get; set; }
        public Empleado Jefe { get; set; } = null;

        public virtual ICollection<Empleado> Empleados { get; set; }

    }
}

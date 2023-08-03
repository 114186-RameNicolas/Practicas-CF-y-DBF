using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Models
{
    public class Cargo
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}

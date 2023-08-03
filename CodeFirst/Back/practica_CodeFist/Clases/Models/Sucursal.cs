using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Models
{
    public class Sucursal
    {

        public Guid Id { get; set; } 
        public string Nombre { get; set; }

        [ForeignKey("IdCiudad")]
        public Guid CiudadId { get; set; }
        public Ciudad ciudad { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }

    }
}

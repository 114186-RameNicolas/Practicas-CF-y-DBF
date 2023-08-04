using System.ComponentModel.DataAnnotations.Schema;

namespace API_CodeFirst_Empleado.Models
{
    public class Sucursal
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;

        [ForeignKey("IdCiudad")]
        public Guid CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        public virtual ICollection<Empleado> Empleados { get; set; }

    }
}

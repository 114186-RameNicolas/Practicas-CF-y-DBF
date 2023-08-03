using System.ComponentModel.DataAnnotations.Schema;

namespace API_CodeFirst_Empleado.Models
{
    public class Empleado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        [ForeignKey("IdCargo")]
        public Guid CargoId { get; set; }
        public Cargo Cargo { get; set; }

        [ForeignKey("IdSucursal")]
        public Guid SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }

        public string DNI { get; set; } = null!;
        public DateTime FechaAlta { get; set; }

        [ForeignKey("IdJefe")]
        public Guid IdJefe { get; set; }
        public Empleado Jefe { get; set; }

    }
}

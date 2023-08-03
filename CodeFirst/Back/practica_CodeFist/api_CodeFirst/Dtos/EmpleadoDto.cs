namespace Api_DbFirst.Dtos
{
    public class EmpleadoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public CargoDto Cargo { get; set; }
        public SucursalDto Sucursal { get; set; }
        public string DNI { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}

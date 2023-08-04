namespace API_CodeFirst_Empleado.Dtos
{
    public class EmpleadoDto : RespuestaBase
    {
        public Guid Id { get; set; } 
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string DNI { get; set; } = null!;
        public SucursalDto Sucursal { get; set; }
        public CargoDto Cargo { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}

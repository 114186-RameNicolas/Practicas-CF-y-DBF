namespace API_CodeFirst_Empleado.Dtos
{
    public class EmpleadoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public SucursalDto Sucursal { get; set; }
        public CargoDto Cargo { get; set; }
    }
}

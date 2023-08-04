namespace API_CodeFirst_Empleado.Dtos
{
    public class SucursalDto
    {
        public Guid Id { get; set; }    
        public string Nombre { get; set; } = null!;
        public CiudadDto Ciudad { get; set; }
    }
}

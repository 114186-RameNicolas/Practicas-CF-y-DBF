namespace API_CodeFirst_Empleado.Dtos
{
    public class SucursalDto
    {
        public Guid Id { get; set; }    
        public string Nombre { get; set; }
        public CiudadDto Ciudad { get; set; }
    }
}

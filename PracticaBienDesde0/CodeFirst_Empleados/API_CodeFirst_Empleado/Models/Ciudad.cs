namespace API_CodeFirst_Empleado.Models
{
    public class Ciudad
    {
        public Guid Id { get; set; }    
        public string Nombre { get; set; } = null!;
        public virtual ICollection<Empleado> Empleados { get; set; }

    }
}

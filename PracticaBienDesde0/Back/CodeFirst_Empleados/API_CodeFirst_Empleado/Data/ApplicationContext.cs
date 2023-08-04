using API_CodeFirst_Empleado.Models;
using Microsoft.EntityFrameworkCore;

namespace API_CodeFirst_Empleado.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }
    }
}

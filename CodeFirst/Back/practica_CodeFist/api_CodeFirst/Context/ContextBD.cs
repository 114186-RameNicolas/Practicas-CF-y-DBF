using Microsoft.EntityFrameworkCore;
using Clases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases.Context
{
    public class ContextBD : DbContext
    {
        public ContextBD()
        {

        }
        public ContextBD(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Sucursal> Sucursal { get; set; }

    }
}

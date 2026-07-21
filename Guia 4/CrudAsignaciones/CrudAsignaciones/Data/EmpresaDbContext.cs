using Microsoft.EntityFrameworkCore;
using CrudAsignaciones.Models;

namespace CrudAsignaciones.Data
{
    public class EmpresaDbContext  : DbContext
    {
        public EmpresaDbContext(DbContextOptions options) : base(options) 
        { 

        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
    }
}

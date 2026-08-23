using CRUD.entidades;
using Microsoft.EntityFrameworkCore;

namespace CRUD.infraestructura.Context
{
    public class alumnoContext : DbContext
    {
        public alumnoContext(DbContextOptions<alumnoContext> options) : base(options)
        {
        }

        public DbSet<Persona> personas { get; set; }
    }
}
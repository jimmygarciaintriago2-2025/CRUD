
using CRUD.entidades;
using Microsoft.EntityFrameworkCore;

namespace CRUD.infraestructura.Context
{
    public class alumnosContext : DbContext
    {
        public alumnosContext(DbContextOptions<alumnosContext> options) : base(options)
        {
        }

        public DbSet<Persona> Persona { get; set; }
    }
}

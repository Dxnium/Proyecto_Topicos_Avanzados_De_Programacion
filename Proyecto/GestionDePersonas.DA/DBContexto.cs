using Microsoft.EntityFrameworkCore;

namespace GestionDePersonas.DA
{
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options)
        {
        }
        public DbSet<GestionDePersonas.Model.Persona> Personas { get; set; }
        public DbSet<GestionDePersonas.Model.Vehiculo> Vehiculos { get; set; }
        public DbSet<GestionDePersonas.Model.Usuario> Usuarios { get; set; }
    }
}

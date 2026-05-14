using lib_servicios.Entidades;
using lib_servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_servicios.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public String? StringConexion { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        public DbSet<Auditorias>? Auditorias { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Peliculas>? Peliculas { get; set; }
      

    }
}

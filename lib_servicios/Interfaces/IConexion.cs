using lib_servicios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace lib_servicios.Interfaces
{
    public interface IConexion
    {
        String? StringConexion { get; set; }
        DbSet<Categorias>? Categorias { get; set; }
        DbSet<Peliculas>? Peliculas { get; set; }
 
        DbSet<Auditorias>? Auditorias { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}

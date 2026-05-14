using lib_servicios.Entidades;

namespace lib_servicios.Interfaces
{
    public interface IPeliculasNegocio
    {
        List<Peliculas> Consultar();
        Peliculas Guardar(Peliculas entidad);
        Peliculas Modificar(Peliculas entidad);
        bool Borrar(int id);
    }
}

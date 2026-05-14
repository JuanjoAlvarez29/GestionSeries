using lib_servicios.Entidades;

namespace presentacion_series.Interfaces
{
    public interface IPeliculasNegocio
    {
        List<Peliculas> Consultar();
        Peliculas Guardar(Peliculas entidad);
        Peliculas Modificar(Peliculas entidad);
        bool Borrar(int id);
    }
}
using lib_servicios.Entidades;

namespace presentacion_series.Interfaces
{
    public interface ICategoriasNegocio
    {
        List<Categorias> Consultar();
        Categorias Guardar(Categorias entidad);
        Categorias Modificar(Categorias entidad);
        bool Borrar(int id);
    }
}
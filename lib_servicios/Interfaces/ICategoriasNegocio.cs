using lib_servicios.Entidades;

namespace lib_servicios.Interfaces
{
   public interface ICategoriasNegocio
    {
        List<Categorias> Consultar();
        Categorias Guardar(Categorias entidad);
        Categorias Modificar(Categorias entidad);
        bool Borrar(int id);
    }
}

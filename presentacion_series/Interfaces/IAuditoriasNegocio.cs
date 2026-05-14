using lib_servicios.Entidades;

namespace presentacion_series.Interfaces
{
    public interface IAuditoriasNegocio
    {
        List<Auditorias> Consultar();
        Auditorias Guardar(Auditorias entidad);
        Auditorias Modificar(Auditorias entidad);
        bool Borrar(int id);
    }
}
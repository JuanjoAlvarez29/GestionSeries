namespace presentacion_series.Interfaces
{
    public interface IComunicacionesNegocio
    {
        Task<Dictionary<string, object>> Ejecutar(Dictionary<string, object> datos);
    }
}

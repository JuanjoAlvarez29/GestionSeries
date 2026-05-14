namespace lib_servicios.Nucleo
{
    public class Configuraciones
    {
        public static string obtener(string clave)
        {
            return "server=localhost\\SQLEXPRESS;Integrated Security=True;TrustServerCertificate=true;database=db_GestionSeries;";
        }
    }
}
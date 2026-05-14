using lib_servicios.Entidades;
using Newtonsoft.Json;
using presentacion_series.Interfaces;



namespace presentacion_series.Implementaciones
{
    public class AuditoriasNegocio : IAuditoriasNegocio
    {
        private IComunicacionesNegocio? iComunicaciones;

        public List<Auditorias> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Auditorias/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Auditorias>();

            return JsonConvert.DeserializeObject<List<Auditorias>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Auditorias/Guardar";
            datos["Metodo"] = "POST";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }

        public Auditorias Modificar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Auditorias/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Auditorias();

            return JsonConvert.DeserializeObject<Auditorias>(
                respuesta["Valor"].ToString()!)!;
        }

        public bool Borrar(int id)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5230/Auditorias/Borrar/{id}";
            datos["Metodo"] = "DELETE";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return false;

            return JsonConvert.DeserializeObject<bool>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
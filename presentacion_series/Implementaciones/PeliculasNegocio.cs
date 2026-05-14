using lib_servicios.Entidades;
using Newtonsoft.Json;
using presentacion_series.Interfaces;

namespace presentacion_series.Implementaciones
{
    public class PeliculasNegocio : IPeliculasNegocio
    {
        private IComunicacionesNegocio? iComunicaciones;

        public List<Peliculas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Peliculas/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Peliculas>();

            return JsonConvert.DeserializeObject<List<Peliculas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Peliculas Guardar(Peliculas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Peliculas/Guardar";
            datos["Metodo"] = "POST";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Peliculas();

            return JsonConvert.DeserializeObject<Peliculas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Peliculas Modificar(Peliculas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Peliculas/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Peliculas();

            return JsonConvert.DeserializeObject<Peliculas>(
                respuesta["Valor"].ToString()!)!;
        }

        public bool Borrar(int id)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5230/Peliculas/Borrar/{id}";
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
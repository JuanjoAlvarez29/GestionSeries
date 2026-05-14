using lib_servicios.Entidades;
using Newtonsoft.Json;
using presentacion_series.Interfaces;

namespace presentacion_series.Implementaciones
{
    public class CategoriasNegocio : ICategoriasNegocio
    {
        private IComunicacionesNegocio? iComunicaciones;

        public List<Categorias> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Categorias/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Categorias>();

            return JsonConvert.DeserializeObject<List<Categorias>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Categorias Guardar(Categorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Categorias/Guardar";
            datos["Metodo"] = "POST";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Categorias();

            return JsonConvert.DeserializeObject<Categorias>(
                respuesta["Valor"].ToString()!)!;
        }

        public Categorias Modificar(Categorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No existe el registro");

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5230/Categorias/Modificar";
            datos["Metodo"] = "PUT";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Categorias();

            return JsonConvert.DeserializeObject<Categorias>(
                respuesta["Valor"].ToString()!)!;
        }

        public bool Borrar(int id)
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = $"http://localhost:5230/Categorias/Borrar/{id}";
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
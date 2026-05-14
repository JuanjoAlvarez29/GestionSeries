using Microsoft.AspNetCore.Mvc;
using lib_servicios.Entidades;
using lib_servicios.Implementaciones;
using lib_servicios.Interfaces;
namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PeliculasController : ControllerBase
    {
        private IPeliculasNegocio? IPeliculasNegocio;

        public PeliculasController()
        {
            this.IPeliculasNegocio = new PeliculasNegocio();
        }

        [HttpGet]
        public List<Peliculas> Consultar()
        {
            if (this.IPeliculasNegocio == null)
                throw new Exception("No implementado");
            return this.IPeliculasNegocio!.Consultar();
        }

        [HttpPost]
        public Peliculas Guardar(Peliculas entidad)
        {
            if (this.IPeliculasNegocio == null)
                throw new Exception("No implementado");
            return this.IPeliculasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Peliculas Modificar(Peliculas entidad)
        {
            if (this.IPeliculasNegocio == null)
                throw new Exception("No implementado");
            return this.IPeliculasNegocio!.Modificar(entidad);
        }

        [HttpDelete("{id}")]
        public bool Borrar(int id)
        {
            if (this.IPeliculasNegocio == null)
                throw new Exception("No implementado");
            return IPeliculasNegocio!.Borrar(id);
        }
    }
}

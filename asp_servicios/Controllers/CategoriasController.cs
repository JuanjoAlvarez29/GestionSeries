using Microsoft.AspNetCore.Mvc;
using lib_servicios.Entidades;
using lib_servicios.Implementaciones;
using lib_servicios.Interfaces;
namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoriasController : ControllerBase
    {
        private ICategoriasNegocio? ICategoriasNegocio;

        public CategoriasController()
        {
            this.ICategoriasNegocio = new CategoriasNegocio();
        }

        [HttpGet]
        public List<Categorias> Consultar()
        {
            if (this.ICategoriasNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriasNegocio!.Consultar();
        }

        [HttpPost]
        public Categorias Guardar(Categorias entidad)
        {
            if (this.ICategoriasNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriasNegocio!.Guardar(entidad);
        }

        [HttpPut]
        public Categorias Modificar(Categorias entidad)
        {
            if (this.ICategoriasNegocio == null)
                throw new Exception("No implementado");
            return this.ICategoriasNegocio!.Modificar(entidad);
        }

        [HttpDelete("{id}")]
        public bool Borrar(int id)
        {
            if (this.ICategoriasNegocio == null)
                throw new Exception("No implementado");
            return ICategoriasNegocio!.Borrar(id);
        }
    }
}

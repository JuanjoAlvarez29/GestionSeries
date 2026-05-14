using lib_servicios.Entidades;
using lib_servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using lib_servicios.Nucleo;

namespace lib_servicios.Implementaciones
{
    public class PeliculasNegocio : IPeliculasNegocio
    {
        private IConexion? iConexion;
        public List<Peliculas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Accion = "Consultar",
                Fecha = DateTime.Now,

            });
            return this.iConexion.Peliculas!.ToList();
        }

        public Peliculas Guardar(Peliculas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");
            //if (string.IsNullOrEmpty(entidad.Cliente))
            //    throw new Exception("El nombre del cliente es requerido");
            //if (entidad.VideojuegosId == 0)
            //    throw new Exception("El videojuego es requerido");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Accion = "Guardar",
                Fecha = DateTime.Now,

            });
            this.iConexion.Peliculas!.Add(entidad!);
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Peliculas Modificar(Peliculas entidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Accion = "Modificar",
                Fecha = DateTime.Now,

            });


            var entry = this.iConexion!.Entry<Peliculas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            return entidad;
        }

        public bool Borrar(int id)
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.obtener("StringConexion");
            this.iConexion.Auditorias!.Add(new Auditorias
            {
                Accion = "Borrar",
                Fecha = DateTime.Now,

            });

            var entidad = new Peliculas();
            entidad.Id = id;
            var entry = this.iConexion!.Entry<Peliculas>(entidad);
            entry.State = EntityState.Deleted;
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}

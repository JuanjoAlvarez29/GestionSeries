using System;
using System.Collections.Generic;
using System.Text;

namespace lib_servicios.Entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string? Accion {  get; set; }
        public int PeliculasId { get; set; }
        public Peliculas? Peliculas { get; set; }

    }
}

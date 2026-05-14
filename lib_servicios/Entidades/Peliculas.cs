using System;
using System.Collections.Generic;
using System.Text;

namespace lib_servicios.Entidades
{
    public class Peliculas
    {
        public int Id { get; set;  }
        public string? Titulo { get; set; }
        public DateOnly Fecha { get; set; }
        public string? Genero { get; set; }
        public int Duracion { get; set; }
        public int CategoriasId { get; set; }
        public Categorias? Categorias { get; set; }  

    }
}

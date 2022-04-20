using System;
using System.ComponentModel.DataAnnotations;

namespace Elecciones.Domain
{
    public class Eleccion
    {
        [Key]
        public long Id { get; set; }        
        public string Titulo { get; set; }
        public string DescripcionTitulo { get; set; }
        public int orden { get; set; }
        public int Estado { get; set; }
    }
}

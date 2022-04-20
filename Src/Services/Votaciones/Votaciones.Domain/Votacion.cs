using System;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Domain
{
    public class Votacion
    {
        [Key]
        public long Id { get; set; }
        public long Id_Eleccion { get; set; }
        public long Id_Candidato { get; set; }
        public long Id_Sufragante { get; set; }
        public int Salto { get; set; }
    }
}

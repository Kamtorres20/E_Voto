using System;
using System.ComponentModel.DataAnnotations;

namespace Votaciones.Domain
{
    public class Votacion
    {
        [Key]
        public long Id { get; set; }
        public int Id_Eleccion { get; set; }
        public int Id_Candidato { get; set; }
        public int Id_Sufragante { get; set; }
        public int Salto { get; set; }
    }
}

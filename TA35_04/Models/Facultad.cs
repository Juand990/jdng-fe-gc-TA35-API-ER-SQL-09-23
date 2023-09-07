using System.Collections.Generic;

namespace TA35_04.Models
{
    public class Facultad
    {
        public Facultad()
        {
            Investigadores = new HashSet<Investigadores>();
            Equipos = new HashSet<Equipos>();
        }
        public int Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Investigadores> Investigadores { get; set; }
        public virtual ICollection<Equipos> Equipos { get; set; }
    }
}

namespace TA35_04.Models
{
    public class Equipos
    {
        public Equipos()
        {
            Reserva = new HashSet<Reserva>();
        }
        public string NumSerie { get; set; }
        public string Nombre { get; set; }
        public int FacultadCod { get; set; }

        public Facultad Facultad { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }

    }
}

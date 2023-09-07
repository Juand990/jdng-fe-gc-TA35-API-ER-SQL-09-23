namespace TA35_04.Models
{
    public class Investigadores
    {
        public Investigadores()
        {
            Reserva = new HashSet<Reserva>();
        }
        public string DNI { get; set; }
        public string NomApels { get; set; }
        public int FacultadCod { get; set; }

        public Facultad Facultad { get; set; }
        public virtual ICollection<Reserva> Reserva { get; set; }

    }
}

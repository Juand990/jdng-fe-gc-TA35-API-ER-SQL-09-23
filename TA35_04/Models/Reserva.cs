namespace TA35_04.Models
{
    public class Reserva
    {
        public string DniInves { get; set; }
        public string NumSerieEq { get; set; }
        public DateTime Comienzo { get; set; }
        public DateTime Fin { get; set; }

        public Investigadores Investigadores { get; set; }
        public Equipos Equipos { get; set; }
    }
}

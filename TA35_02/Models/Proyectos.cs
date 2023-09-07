namespace TA35_02.Models
{
    public partial class Proyectos
    {
        public Proyectos()
        {
            AsignadoA = new HashSet<AsignadoA>();
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public int Horas { get; set; }

        public virtual ICollection<AsignadoA> AsignadoA { get; set; }
    }
}

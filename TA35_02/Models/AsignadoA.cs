namespace TA35_02.Models
{
    public partial class AsignadoA
    {
        public string CientificoDni { get; set; }
        public string ProyectoId { get; set; }
        public virtual Cientificos Cientificos { get; set; }
        public virtual Proyectos Proyectos { get; set; }
    }
}

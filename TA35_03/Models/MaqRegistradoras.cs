namespace TA35_03.Models
{
    public partial class MaqRegistradoras
    {
        public MaqRegistradoras()
        {
            Venta = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public int Piso { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }

    }
}

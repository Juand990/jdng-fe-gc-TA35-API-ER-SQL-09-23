using System.Collections.Generic;

namespace TA35_01.Models
{
    public partial class Piezas
    {
        public Piezas()
        {
            Suministra=new HashSet<Suministra>();
        }
        public int Codigo { get; set; }
        public string? Nombre { get; set; }
        public virtual ICollection<Suministra> Suministra { get; set; }
    }
}

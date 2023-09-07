using System.Collections.Generic;

namespace TA35_02.Models
{
    public partial class Cientificos
    {
        public Cientificos()
        {
            AsignadoA = new HashSet<AsignadoA>();
        }
        public string DNI { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<AsignadoA> AsignadoA { get; set; }
    }
}

﻿namespace TA35_03.Models
{
    public partial class Cajeros
    {
        public Cajeros()
        {
            Venta = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public string NomApels { get; set; }

        public virtual ICollection<Venta> Venta { get; set; }
    }
}

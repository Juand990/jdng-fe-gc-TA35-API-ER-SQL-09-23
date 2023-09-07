namespace TA35_03.Models
{
    public partial class Venta
    {
        public int CajeroId { get; set; }
        public int ProductoId { get; set; }
        public int MaquinaId { get; set; }


        public Cajeros Cajero{ get; set; }
        public Productos Producto { get; set; }
        public MaqRegistradoras Maquina { get; set; }

    }
}

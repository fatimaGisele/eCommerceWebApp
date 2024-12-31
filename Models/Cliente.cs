namespace appPDWebMVC.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Mail {  get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public int Telefono { get; set; }
        public int Rol { get; set; }
        public ICollection<ClienteCarrito> clienteCarritos { get; set; } = new List<ClienteCarrito>();
        public ICollection<ClienteMediodepago> clienteMediodepagos { get; set; } = new List<ClienteMediodepago>();
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();

    }
}

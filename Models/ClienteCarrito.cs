namespace appPDWebMVC.Models
{
    public class ClienteCarrito
    {
        public int ClienteId { get; set; }
        public int CarritoId {  get; set; }
        public int Cantidad { get; set; }
        public virtual Cliente ClienteNav { get; set; } = null!;
        public virtual Carrito CarritoNav { get; set; } = null!;

    }
}

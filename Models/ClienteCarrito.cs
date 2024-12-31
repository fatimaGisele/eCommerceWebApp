namespace appPDWebMVC.Models
{
    public class ClienteCarrito
    {
        public int ClienteId { get; set; }
        public int CarritoId {  get; set; }
        public int Cantidad { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual Carrito Carrito { get; set; } = null!;
    }
}

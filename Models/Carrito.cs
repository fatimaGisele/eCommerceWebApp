namespace appPDWebMVC.Models
{
    public class Carrito
    {
        public int ID { get; set; }
        public int IndumentariaId {  get; set; }
        public double MontoTotal {  get; set; }
        public Cliente Cliente { get; set; } = null!;
        public virtual ICollection<ClienteCarrito> ClienteCarrito { get; set; } = new List<ClienteCarrito>();
    }
}

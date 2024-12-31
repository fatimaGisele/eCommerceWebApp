namespace appPDWebMVC.Models
{
    public class Venta
    {
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public Venta()
        {
            this.Fecha = DateTime.Now;
        }
    }
}

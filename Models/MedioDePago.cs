namespace appPDWebMVC.Models
{
    public class MedioDePago
    {
        public int ID { get; set; }
        public int Numero {  get; set; }
        public virtual ICollection<ClienteMediodepago> ClienteMediodepagos { get; set; } = new List<ClienteMediodepago>();
    }
}

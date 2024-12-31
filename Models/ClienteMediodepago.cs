namespace appPDWebMVC.Models
{
    public class ClienteMediodepago
    {
        public int ClienteId { get; set; }
        public int MedioDePagoId { get; set; }
        public string Tipo { get; set; } = null!;
        public virtual Cliente Cliente { get; set; }=null!; 
        public virtual MedioDePago MedioDePago { get; set;} =null!;
    }
}

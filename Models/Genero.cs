namespace appPDWebMVC.Models
{
    public class Genero
    {
        public int ID { get; set; }
        public string GeneroTipo { get; set; } = null!;
        public virtual ICollection<Indumentarium> Indumentaria { get; set; } = new List<Indumentarium>();   

    }
}

namespace appPDWebMVC.Models
{
    public class Indumentarium
    {
        public int ID {  get; set; }
        public string Nombre { get; set; } = null!;
        public string Tipo { get; set; } = null!;
        public string Detalle {  get; set; } = null!;
        public double Precio {  get; set; }
        public int Talle {  get; set; }
        public int Stock {  get; set; }
        public string Img { get; set; } = null!;
        public int CategoriaId { get; set; }
        public int GeneroId { get; set; }
        public virtual Categorium Categoria { get; set; } = null!;
        public virtual Genero Genero { get; set; } = null!;
    }
}

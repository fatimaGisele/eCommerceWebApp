﻿namespace appPDWebMVC.Models
{
    public class Categorium
    {
        public int ID { get; set; }

        public string CategoriaNombre { get; set; } = null!;
        public ICollection<Indumentarium> Indumentaria { get; set; } = new List<Indumentarium>();
    }
}

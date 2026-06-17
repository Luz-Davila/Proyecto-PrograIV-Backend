namespace HackerRank1.Entities
{
    public class InventarioItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public string Uso { get; set; }
        public string Imagen { get; set; }
        public bool Activo { get; set; } = true;
    }
}
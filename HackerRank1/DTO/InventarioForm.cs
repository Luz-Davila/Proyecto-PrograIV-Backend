namespace HackerRank1.DTO
{
    public class InventarioForm
    {
        // Estos son los datos exactos que tu React envía cuando se hace el POST
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public string Uso { get; set; }
        public string Imagen { get; set; }
    }
}
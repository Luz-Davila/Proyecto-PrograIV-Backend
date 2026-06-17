namespace LibraryService.WebAPI.DTO
{
    public class AveriaForm
    {
        public string Nombre { get; set; } = string.Empty;
        public string TipoAveria { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = "Pendiente";
    }
}
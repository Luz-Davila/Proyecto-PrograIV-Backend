using System.ComponentModel.DataAnnotations;

namespace LibraryService.WebAPI.Data
{
    public class SystemUser
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Cedula { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}

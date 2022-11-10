using System.ComponentModel.DataAnnotations;

namespace Beca.ConciertoInfo.API.Models
{
    public class ConciertoForCreationDto
    {
        [Required(ErrorMessage = "Debería introducir un Nombre.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}


namespace Beca.ConciertoInfo.API.Models
{
    public class ConciertoWithoutCancionesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
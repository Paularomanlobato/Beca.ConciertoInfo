namespace Beca.ConciertoInfo.API.Models
{
    public class ConciertoDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int NumberOfCanciones
        {
            get
            {
                return Canciones.Count;
            }
        }

        public ICollection<CancionDto> Canciones { get; set; }
            = new List<CancionDto>();
    }
}
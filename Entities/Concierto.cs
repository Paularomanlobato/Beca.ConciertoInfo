using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beca.ConciertoInfo.API.Entities
{
    public class Concierto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public ICollection<Cancion> Canciones { get; set; }
               = new List<Cancion>();

        public Concierto(string name)
        {
            Name = name;
        }
    }
}

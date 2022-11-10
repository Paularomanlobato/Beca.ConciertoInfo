using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beca.ConciertoInfo.API.Entities
{
    public class Cancion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("ConciertoId")]
        public Concierto? Concierto { get; set; }
        public int ConciertoId { get; set; }

        public Cancion(string name)
        {
            Name = name;
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAudio.Entities
{
    public class NoiDung : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string TaskId { get; set; }
        [Required, MaxLength(50)]
        public string? Channel { get; set; }
        public float? Start { get; set; }
        public float? End { get; set; }
        public string? Text { get; set; }
        public string? Text_norm { get; set; }
    }
}

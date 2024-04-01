using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAudio.Entities
{
    public class QuanLyFile : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string TaskId { get; set; }
        [Required, MaxLength(50)]
        public string FileName { get; set; }
        [Required, MaxLength(300)]
        public DateTime DateToFile { get; set; }  
        public bool IsStatus { get; set; }
    }
}

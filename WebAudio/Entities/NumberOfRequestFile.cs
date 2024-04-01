using System.ComponentModel.DataAnnotations;

namespace WebAudio.Entities
{
    public class NumberOfRequestFile
    {
        public int Id { get; set; }
        [Required]
        public int? NumberRequestFile { get; set; }
    }
}

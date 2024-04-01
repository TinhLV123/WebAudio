using System.ComponentModel.DataAnnotations;

namespace WebAudio.Dtos
{
    public class NoiDungDto
    {
        public int Id { get; set; }
        public string? TaskId { get; set; }
        public string? Channel { get; set; }
        public float? Start { get; set; }
        public float? End { get; set; }
        public string? Text { get; set; }
        public string? Text_norm { get; set; }
    }
}

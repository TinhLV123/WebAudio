using System.ComponentModel.DataAnnotations;

namespace WebAudio.Entities
{
    public class BaseEntity
    {
        [Required, MaxLength(255)]
        public string? NguoiTao { get; set; } = "";
        [Required]
        public DateTime ThoiGianTao { get; set; } = DateTime.Now;
        [MaxLength(255)]
        public string? NguoiCapNhat { get; set; } = "";
        [Required]
        public DateTime ThoiGianCapNhat { get; set; } = DateTime.Now;
        [Required]
        public bool Deleted { get; set; } = false;
    }
}

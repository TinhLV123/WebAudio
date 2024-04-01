namespace WebAudio.Dtos
{
    public class QuanLyFileDto
    {
        public int Id { get; set; }
        public string? TaskId { get; set; }
        public string? FileName { get; set; }
        public DateTime DateToFile { get; set; }
        public bool IsStatus { get; set; }
        public string? NguoiTao { get; set; }
        public DateTime ThoiGianTao { get; set; }
        public string? NguoiCapNhat { get; set; }
        public DateTime ThoiGianCapNhat { get; set; }
    }
}

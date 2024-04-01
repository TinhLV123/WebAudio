namespace WebAudio.Dtos
{
    public class FromFileDto
    {
        public string? msg { get; set; }
        public int status { get; set; }
        public string task_id { get; set; }
    }
    public class DsNoiDungDto
    {
        public string? call_id { get; set; }
        public string? msg { get; set; }
        public int progress { get; set; }
        public Result result { get; set; } = new Result();
        public int status { get; set; }
        public string? task_id { get; set; }
    }
}

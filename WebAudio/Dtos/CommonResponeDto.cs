namespace WebAudio.Dtos
{
    public class CommonResponeDto
    {
        public CommonResponeDto()
        {
            this.flag = false;
            this.msg = "";
            this.code = "";
        }

        public bool flag { get; set; }
        public string msg { get; set; }
        public string code { get; set; }
        public dynamic value { get; set; }
    }
}

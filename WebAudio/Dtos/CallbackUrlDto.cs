namespace WebAudio.Dtos
{

    public class ChaoKhachHang
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class Content
    {
        public int Id { get; set; }
        public string? channel { get; set; }
        public float? confidence { get; set; }
        public float? end { get; set; }
        public float? start { get; set; }
        public string? text { get; set; }
        public string? text_norm { get; set; }
        public string? utt_segment { get; set; }
    }

    public class GoiLaiTongDai
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class HoiTen
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class KhachHangKhongChoMayLau
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class KhachHangKhongChoMayNhieuLan
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class NhuCauThem
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; }
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class Result
    {
        public string? audio_path { get; set; }
        public List<Content> content { get; set; } = new List<Content>();
        public double processing_time { get; set; }
        public ResultPattern result_pattern { get; set; } = new ResultPattern();    
        public ResultTopic result_topic { get; set; } = new ResultTopic();
    }

    public class ResultPattern
    {
        public ChaoKhachHang chao_khach_hang { get; set; } = new ChaoKhachHang();
        public GoiLaiTongDai goi_lai_tong_dai { get; set; } = new GoiLaiTongDai();
        public HoiTen hoi_ten { get; set; } = new HoiTen();
        public KhachHangKhongChoMayLau khach_hang_khong_cho_may_lau { get; set; } = new KhachHangKhongChoMayLau();
        public KhachHangKhongChoMayNhieuLan khach_hang_khong_cho_may_nhieu_lan { get; set; } = new KhachHangKhongChoMayNhieuLan();
        public NhuCauThem nhu_cau_them { get; set; } = new NhuCauThem();
        public SanSangPhucVu san_sang_phuc_vu { get; set; } = new SanSangPhucVu();
        public TamBiet tam_biet { get; set; } = new TamBiet();
        public TamBietKhachHangBangTen tam_biet_khach_hang_bang_ten { get; set; } = new TamBietKhachHangBangTen();
        public TapTrungLangNghe tap_trung_lang_nghe { get; set; } = new TapTrungLangNghe();
        public XinChao xin_chao { get; set; } = new XinChao();
    }

    public class ResultTopic
    {
        public List<TopicsBest> topics_best { get; set; } = new List<TopicsBest> { };
        public List<TopicsDetail> topics_detail { get; set; } = new List<TopicsDetail> { };
    }


    public class SanSangPhucVu
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; } = new List<object> { };
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class TamBiet
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; } = new List<object> { };
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class TamBietKhachHangBangTen
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; } = new List<object> { };
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class TapTrungLangNghe
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; } = new List<object> { };
        public string? description { get; set; }
        public string? name { get; set; }
    }

    public class TopicsBest
    {
        public double topic_confidence { get; set; }
        public string? topic_description { get; set; }
        public string? topic_id { get; set; }
        public string? topic_name { get; set; }
    }

    public class TopicsDetail
    {
        public double topic_confidence { get; set; }
        public string? topic_description { get; set; }
        public string? topic_id { get; set; }
        public string? topic_name { get; set; }
    }

    public class XinChao
    {
        public bool appear { get; set; }
        public List<object> appear_segments { get; set; } = new List<object> { };
        public string? description { get; set; }
        public string? name { get; set; }
    }
}

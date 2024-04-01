using WebAudio.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebAudio.Data
{
    public class WebAudioDbContext : DbContext
    {
        public WebAudioDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<QuanLyFile> QuanLyFiles { get; set; }
        public virtual DbSet<NoiDung> NoiDungs { get; set; }
        public virtual DbSet<NumberOfRequestFile> NumberOfRequestFiles { get; set; }

    }
}

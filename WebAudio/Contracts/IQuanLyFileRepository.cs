
using WebAudio.Dtos;
using WebAudio.Entities;

namespace WebAudio.Contracts
{
    public interface IQuanLyFileRepository
    {
        public Task<List<QuanLyFileDto>> GetList_QuanLyFile();
        public Task<List<NoiDungDto>> Get_NoiDungByTaskId(string? task_id);
        public Task<CommonResponeDto> Insert_QuanLyFile(QuanLyFileDto _quanlyfile);
    }
}

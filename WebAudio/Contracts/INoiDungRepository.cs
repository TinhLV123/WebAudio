
using WebAudio.Dtos;
using WebAudio.Entities;

namespace WebAudio.Contracts
{
    public interface INoiDungRepository
    {
        public Task<CommonResponeDto> Insert_NoiDung(DsNoiDungDto obj_kqcd,string task_id);
        public Task<CommonResponeDto> CallBack_Url(DsNoiDungDto obj);
        Task<bool> UpdateTrangThaiQuanLyFile(string task_id);
    }
}

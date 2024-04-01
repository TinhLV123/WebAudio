using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using WebAudio.Contracts;
using WebAudio.Dtos;
using WebAudio.Entities;

namespace WebAudio.Controllers
{
    [ApiController]
    [Route("api/noidung")]
    public class NoiDungController : ControllerBase
    {
        private readonly INoiDungRepository _noidungRepository;
        public NoiDungController(INoiDungRepository noidudngRepository)
        {

            _noidungRepository = noidudngRepository;
        }
        [HttpPost("insert_noidung")]
        public async Task<IActionResult> Insert_NoiDung(string task_id)
        {
            try
            {
                //Lấy kết quả chủ động
                var client_kqcd = new RestClient();
                var request_kqcd = new RestRequest("http://103.141.141.15:8089/api/asr/vad/channel/v1/get_task/"+ task_id, Method.Get);
                RestResponse response_kqcd = await client_kqcd.ExecuteAsync(request_kqcd);
                var obj_kqcd = JsonConvert.DeserializeObject<DsNoiDungDto>(response_kqcd.Content);

                // insert Noidung
                var result = await _noidungRepository.Insert_NoiDung(obj_kqcd, task_id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(500);
            }
        }

        [HttpPost("callback_url")]
        public async Task<IActionResult> CallBack_Url(DsNoiDungDto obj)
        {
            var result = await _noidungRepository.CallBack_Url(obj);
            return Ok(result);
        }
    }
}
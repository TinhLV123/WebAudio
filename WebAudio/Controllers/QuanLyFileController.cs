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
    [Route("api/quanlyfile")]
    public class QuanLyFileController : ControllerBase
    {
        private readonly IQuanLyFileRepository _quanLyFileRepository;
        public QuanLyFileController(IQuanLyFileRepository quanLyFileRepository)
        {
            _quanLyFileRepository = quanLyFileRepository;
        }
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList_QuanLyFile()
        {
            try
            {
                List<QuanLyFileDto> result = await _quanLyFileRepository.GetList_QuanLyFile();
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(500);
            }
        }
        [HttpGet("get_NoiDungByTaskID")]
        public async Task<IActionResult> Get_NoiDungByTaskId(string? task_id)
        {
            try
            {
                List<NoiDungDto> result = await _quanLyFileRepository.Get_NoiDungByTaskId(task_id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(500);
            }
        }
        [HttpPost("insert_quanlyfile")]
        public async Task<IActionResult> Insert_QuanLyFile(IFormFile audio_file)
        {
            try
            {

                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string filePath = Path.Combine(uploadsFolder, audio_file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await audio_file.CopyToAsync(fileStream);
                }

                var client = new RestClient();
                var request = new RestRequest("http://103.141.141.15:8089/api/asr/vad/channel/v1/submit_task", Method.Post);
                request.AlwaysMultipartFormData = true;
                request.AddFile("audio-file", filePath);
                request.AddParameter("token", "iaKglGRsR8wlzx5hEcJJ3U2GlgaaMIqA");
                request.AddParameter("callback-url", "http://abc.com");
                RestResponse response = await client.ExecuteAsync(request);

                var objres = JsonConvert.DeserializeObject<FromFileDto>(response.Content);

                // insert QuanLyFile
                var result = new CommonResponeDto();
                var _quanlyfile = new QuanLyFileDto();

                _quanlyfile.TaskId = objres.task_id;
                _quanlyfile.FileName = audio_file.FileName;
                _quanlyfile.NguoiTao = "tinhlv";
                _quanlyfile.ThoiGianTao = DateTime.Now;
                _quanlyfile.NguoiCapNhat = "tinhlv";
                _quanlyfile.ThoiGianCapNhat = DateTime.Now;

                result = await _quanLyFileRepository.Insert_QuanLyFile(_quanlyfile);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return StatusCode(500);
            }
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Serilog;
using System.Threading.Channels;
using WebAudio.Contracts;
using WebAudio.Data;
using WebAudio.Dtos;
using WebAudio.Entities;

namespace WebAudio.Repositories
{
    public class QuanLyFileRepository : IQuanLyFileRepository
    {
        private readonly WebAudioDbContext _context;
        public QuanLyFileRepository(WebAudioDbContext context)
        {
            _context = context;
        }
        public async Task<List<QuanLyFileDto>> GetList_QuanLyFile()
        {
            try
            {
                var query =
                    from quanlyfile in _context.QuanLyFiles.Where(x => !x.Deleted)

                    select new QuanLyFileDto
                    {
                        Id = quanlyfile.Id,
                        TaskId = quanlyfile.TaskId,
                        FileName = quanlyfile.FileName,
                        DateToFile = quanlyfile.DateToFile,
                        IsStatus = quanlyfile.IsStatus
                    };
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"GetList_QuanLyFile Exception: {ex.ToString()}");
                return new List<QuanLyFileDto>();
            }
        }
        public async Task<NumberOfRequestFile> GetMax_NumberOfRequestFile()
        {
            try
            {
                var maxNumberOfRequest = _context.NumberOfRequestFiles.Max(e => e.NumberRequestFile);

                var entityWithMaxNumberOfRequest = _context.NumberOfRequestFiles
                    .FirstOrDefault(e => e.NumberRequestFile == maxNumberOfRequest);

                return entityWithMaxNumberOfRequest;
            }
            catch (Exception ex)
            {
                Log.Error($"GetMax_NumberOfRequestFile Exception: {ex.ToString()}");
                return new NumberOfRequestFile();
            }
        }
        public async Task<List<NoiDungDto>> Get_NoiDungByTaskId(string? task_id)
        {
            try
            {
                return await _context.NoiDungs.Where(x => x.Deleted == false && x.TaskId == task_id).Select(x => new NoiDungDto()
                {
                    Id = x.Id,
                    TaskId = x.TaskId,
                    Channel = x.Channel,
                    Start = x.Start,
                    End = x.End,
                    Text = x.Text,
                    Text_norm = x.Text_norm,
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.Error($"Get_NoiDungByTaskId Exception: {ex.Message}");
                return new List<NoiDungDto>();
            }
        }

        public async Task<CommonResponeDto> Insert_QuanLyFile(QuanLyFileDto obj)
        {
            var _a = await GetMax_NumberOfRequestFile();
            if (_a == null || _a.NumberRequestFile < 1000)
            {
                var _quanlyfile = new QuanLyFile();
                _quanlyfile.Id = obj.Id;
                _quanlyfile.TaskId = obj.TaskId;
                _quanlyfile.FileName = obj.FileName;
                _quanlyfile.DateToFile = DateTime.Now;
                _quanlyfile.IsStatus = false;
                await _context.QuanLyFiles.AddAsync(_quanlyfile);
                await _context.SaveChangesAsync();
                //insert numberofrequestfile
                if (_a == null)
                {
                    var _number = new NumberOfRequestFile();
                    _number.Id = obj.Id;
                    _number.NumberRequestFile = 1;

                    await _context.NumberOfRequestFiles.AddAsync(_number);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var _number = new NumberOfRequestFile();
                    _number.Id = obj.Id;
                    _number.NumberRequestFile = _a.NumberRequestFile++;

                    await _context.NumberOfRequestFiles.AddAsync(_number);
                    await _context.SaveChangesAsync();
                }

                return new CommonResponeDto() { flag = true, msg = "Tác vụ thực hiện thành công.", value = 1 };
            }
            else
            {
                return new CommonResponeDto() { flag = false, msg = "Không được thêm quá 1000 file.", value = -2 };
            }

        }
    }
}

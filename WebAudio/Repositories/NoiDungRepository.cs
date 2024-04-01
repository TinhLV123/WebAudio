using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using Serilog;
using WebAudio.Contracts;
using WebAudio.Data;
using WebAudio.Dtos;
using WebAudio.Entities;
using WebAudio.Migrations;

namespace WebAudio.Repositories
{
    public class NoiDungRepository : INoiDungRepository
    {
        private readonly WebAudioDbContext _context;
        public NoiDungRepository(WebAudioDbContext context)
        {
            _context = context;
        }
        public async Task<CommonResponeDto> Insert_NoiDung( DsNoiDungDto obj_kqcd, string task_id)
        {
            var _noidung = new NoiDung();
            foreach (var item in obj_kqcd.result.content)
            {
                _noidung.Id = item.Id;
                _noidung.TaskId = task_id;
                _noidung.Channel = item.channel;
                _noidung.End = item.end;
                _noidung.Start = item.start;
                _noidung.Text = item.text;
                _noidung.Text_norm = item.text_norm;
                _noidung.NguoiTao = "tinhlv";
                _noidung.ThoiGianTao = DateTime.Now;
                _noidung.NguoiCapNhat = "tinhlv";
                _noidung.ThoiGianCapNhat = DateTime.Now;
                await _context.NoiDungs.AddAsync(_noidung);
                await _context.SaveChangesAsync();
            }
            await UpdateTrangThaiQuanLyFile(task_id);

            return new CommonResponeDto() { flag = true, msg = "Tác vụ thực hiện thành công.", value = 1 };

        }
        public async Task<bool> UpdateTrangThaiQuanLyFile(string task_id)
        {
            var _Update = await _context.QuanLyFiles.FirstOrDefaultAsync(x => x.TaskId == task_id);
            _Update.IsStatus = true;
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<CommonResponeDto> CallBack_Url(DsNoiDungDto obj_kqcd)
        {
            var _noidung = new NoiDung();
            foreach (var item in obj_kqcd.result.content)
            {
                _noidung.Id = item.Id;
                _noidung.TaskId = obj_kqcd.task_id;
                _noidung.Channel = item.channel;
                _noidung.End = item.end;
                _noidung.Start = item.start;
                _noidung.Text = item.text;
                _noidung.Text_norm = item.text_norm;
                _noidung.NguoiTao = "tinhlv";
                _noidung.ThoiGianTao = DateTime.Now;
                _noidung.NguoiCapNhat = "tinhlv";
                _noidung.ThoiGianCapNhat = DateTime.Now;
                await _context.NoiDungs.AddAsync(_noidung);
                await _context.SaveChangesAsync();
            }
            await UpdateTrangThaiQuanLyFile(obj_kqcd.task_id);

            return new CommonResponeDto() { flag = true, msg = "Tác vụ thực hiện thành công.", value = 1 };

        }
    }
}

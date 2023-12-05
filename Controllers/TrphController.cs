using Microsoft.AspNetCore.Mvc;
using NT118_Server_API.Models;

namespace NT118_Server_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrphController : Controller
    {
        private readonly ILogger<TrphController> _logger;
        public TrphController(ILogger<TrphController> logger)
        {
            _logger = logger;
        }
        private bool Authentication(NhanVien trph, string? maph = null)
        {
            DataBase db = new DataBase();
            if (db.Login(trph.MANV, trph.MK) != true) return false;
            if (!db.CheckIfTRPHExists(trph.MANV)) return false;
            if (maph != null)
            {
                NhanVien? nhanVien = db.GetPHBanFromNhanVien(trph.MANV);
                if (nhanVien != null && nhanVien.PHBAN == maph) return true;
                else return false;
            }
            return false;
        }
        [HttpPost]
        [Route("ThemCongViec")]
        public async Task<IActionResult> ThemCongViec(KeyValuePair<NhanVien,LichLamViec> data)
        {
            DataBase db = new DataBase();
            if (Authentication(data.Key, data.Value.PhBan))
            {
                db.ThemCongViec(data.Value);
                return Ok();
            }
            return BadRequest("Authentication failed");
        }
        [HttpPost]
        [Route("XoaCongViec")]
        public async Task<IActionResult> XoaCongViec(KeyValuePair<NhanVien,LichLamViec> data)
        {
            DataBase db = new DataBase();
            if (Authentication(data.Key, data.Value.PhBan))
            {
                db.XoaCongViec(data.Value);
                return Ok();
            }
            return BadRequest("Authentication failed");
        }
        [HttpPost]
        [Route("SuaCongViec")]
        public async Task<IActionResult> SuaCongViec(KeyValuePair<NhanVien,LichLamViec> data)
        {
            DataBase db = new DataBase();
            if (Authentication(data.Key, data.Value.PhBan))
            {
                db.SuaCongViec(data.Value);
                return Ok();
            }
            return BadRequest("Authentication failed");
        }
        [HttpPost]
        [Route("ThemNhanVienVaoCongViec")]
        public async Task<IActionResult> ThemNhanVienVaoCongViec(KeyValuePair<NhanVien,KeyValuePair<LichLamViec,NhanVien>> data)
        {
            DataBase db = new DataBase();
            if (Authentication(data.Key, data.Value.Key.PhBan))
            {
                db.ThemNhanVienVaoCongViec(data.Value.Key, data.Value.Value);
                return Ok();
            }
            return BadRequest("Authentication failed");
        }
        [HttpPost]
        [Route("XoaNhanVienKhoiCongViec")]
        public async Task<IActionResult> XoaNhanVienKhoiCongViec(KeyValuePair<NhanVien,KeyValuePair<LichLamViec,NhanVien>> data)
        {
            DataBase db = new DataBase();
            if (Authentication(data.Key, data.Value.Key.PhBan))
            {
                db.XoaNhanVienKhoiCongViec(data.Value.Key, data.Value.Value);
                return Ok();
            }
            return BadRequest("Authentication failed");
        }
        [HttpPost]
        [Route("LaySoLuongNhanVienTrongCongViec")]
        public async Task<IActionResult> LaySoLuongNhanVienTrongCongViec(KeyValuePair<NhanVien, LichLamViec> data)
        {
            DataBase db = new DataBase();
            if (Authentication(data.Key, data.Value.PhBan))
            {
                return Ok(db.LaySoLuongNhanVienTrongCongViec(data.Value));
            }
            return BadRequest("Authentication failed");
        }
        [HttpPost]
        [Route("LayDanhSachNhanVienTrongCongViecCuaPhongBan")]
        public async Task<IActionResult> LayDanhSachNhanVienTrongCongViecCuaPhongBan(KeyValuePair<NhanVien, LichLamViec> data)
        {
            DataBase db = new DataBase();
            if (Authentication(data.Key, data.Value.PhBan))
            {
                return Ok(db.LayDanhSachNhanVienTrongCongViecCuaPhongBan(data.Value));
            }
            return BadRequest("Authentication failed");
        }
        [HttpPost]
        [Route("LayDanhSachCongViecCuaPhongBan")]
        public async Task<IActionResult> LayDanhSachCongViecCuaPhongBan(KeyValuePair<NhanVien, LichLamViec> data)
        {
            DataBase db = new DataBase();
            if (Authentication(data.Key, data.Value.PhBan))
            {
                return Ok(db.LayDanhSachCongViecCuaPhongBan(data.Value));
            }
            return BadRequest("Authentication failed");
        }

    }
}

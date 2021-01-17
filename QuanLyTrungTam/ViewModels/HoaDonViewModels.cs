using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.ViewModels
{
    public class HoaDonViewModels
    {
        public int MaHoaDon { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        public DateTime? NgayLap { get; set; }

        public string GhiChu { get; set; }

        public bool TinhTrang { get; set; } = false;

        public int? MaKhoaHoc { get; set; }

        public int? MaLopHoc { get; set; }

        public int? MaHocVien { get; set; }

        public int SoLuong { get; set; }
    }
}
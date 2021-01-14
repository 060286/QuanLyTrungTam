using Models.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyTrungTam.ViewModels
{
    public class KhoaHocDetailsViewModels
    {
        // Course

        public int MaKhoaHoc { get; set; }

        public string TenKhoaHoc { get; set; }

        public int SoLuong { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public DateTime NgayBatDau { get; set; }

        public decimal GiaTien { get; set; }

        public int TinhTrang { get; set; }

        public string Mota { get; set; }

        public int SoTuan { get; set; }

        public int LuaTuoiPhuHop { get; set; }

        public int MaDanhMuc { get; set; }

        // Schedule 

        public int MaTKB { get; set; }

        public bool ThuHai { get; set; } 

        public bool ThuBa { get; set; } 

        public bool ThuTu { get; set; }

        public bool ThuNam { get; set; } 

        public bool ThuSau { get; set; }

        public bool ThuBay { get; set; } 

        public bool ChuNhat { get; set; }

        public string ThoiGianHoc { get; set; }
    }
}
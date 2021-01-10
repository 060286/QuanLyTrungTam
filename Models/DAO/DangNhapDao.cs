using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DangNhapDao
    {
        private eCenterDbContext _context = null;

        public DangNhapDao()
        {
            _context = new eCenterDbContext();
        }

        public bool UpdateAccount(DangNhap entity)
        {
            try
            {
                var dangNhap = _context.DangNhaps.Find(entity.MaTaiKhoan);
                dangNhap.MaVaiTro = entity.MaVaiTro;
                dangNhap.TenNguoiDung = entity.TenNguoiDung;
                dangNhap.TrangThai = entity.TrangThai;

                _context.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}

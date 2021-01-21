using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ThoiKhoaBieuDao
    {
        public eCenterDbContext _context = null;

        // Constructor
        public ThoiKhoaBieuDao()
        {
            _context = new eCenterDbContext();
        }


        public int Insert(ThoiKhoaBieu tkb)
        {
            _context.ThoiKhoaBieux.Add(tkb);
            _context.SaveChanges();
            return tkb.MaTKB;
        }

        public ThoiKhoaBieu ViewDetail(int id)
        {
            return _context.ThoiKhoaBieux.Find(id);
        }

        public ThoiKhoaBieu ViewDetailsByMaKhoaHoc(int id)
        {
            return _context.ThoiKhoaBieux.FirstOrDefault(x => x.MaKhoaHoc == id);
        }

        public ThoiKhoaBieu getScheduleByCourse(int id)
        {
            return _context.ThoiKhoaBieux.FirstOrDefault(x => x.MaKhoaHoc == id);
        }


        public bool Update(ThoiKhoaBieu tkb)
        {
            try
            {
                var _tkb = _context.ThoiKhoaBieux.Find(tkb.MaTKB);
                _tkb.ThoiGianHoc = tkb.ThoiGianHoc;
                _tkb.ThuHai = tkb.ThuHai;
                _tkb.ThuBa = tkb.ThuBa;
                _tkb.ThuTu = tkb.ThuTu;
                _tkb.ThuNam = tkb.ThuNam;
                _tkb.ThuSau = tkb.ThuSau;
                _tkb.ThuBa = tkb.ThuBa;
                _tkb.ChuNhat = tkb.ChuNhat;

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

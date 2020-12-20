using Models.Framework;
using System;
using System.Linq;

namespace Models.DAO
{
    class BangDiemDao
    {
        private eCenterDbContext _context = null; 

        public BangDiemDao()
        {
            _context = new eCenterDbContext();
        }

        public int Insert(BangDiem bangDiem)
        {
            _context.BangDiems.Add(bangDiem);
            _context.SaveChanges();
            return bangDiem.MaBangDiem;
        }

        public string GetById(int maBangDiem)
        {
            return _context.BangDiems.SingleOrDefault(x => x.MaBangDiem == maBangDiem).ToString();
        }

        public BangDiem ViewDetail(int id)
        {
            return _context.BangDiems.Find(id);
        }

        public bool Update(BangDiem entity)
        {
            try
            {
                var _bangDiem = _context.BangDiems.Find(entity.MaBangDiem);
                _bangDiem.KetQua = entity.KetQua;
                _bangDiem.KT1 = entity.KT1;
                _bangDiem.KT2 = entity.KT2;
                _bangDiem.THIL1 = entity.THIL1;
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}

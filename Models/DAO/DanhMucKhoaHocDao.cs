using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DanhMucKhoaHocDao
    {
        eCenterDbContext _context = null;

        public DanhMucKhoaHocDao()
        {
            _context = new eCenterDbContext();
        }

        public List<DanhMucKhoaHoc> ListAll()
        {
            return _context.DanhMucKhoaHocs.ToList();
        }

        public int Insert(DanhMucKhoaHoc entity)
        {
            _context.DanhMucKhoaHocs.Add(entity);
            _context.SaveChanges();
            return entity.MaDanhMuc;
        }

        public DanhMucKhoaHoc GetById(int maDanhMuc)
        {
            return _context.DanhMucKhoaHocs.SingleOrDefault(x => x.MaDanhMuc == maDanhMuc);
        }
    }
}

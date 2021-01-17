using Models.Framework;
using PagedList;
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

        public IEnumerable<DanhMucKhoaHoc> ListAllPaging(string  searchString,int page, int pageSize)
        {
            IQueryable<DanhMucKhoaHoc> model = _context.DanhMucKhoaHocs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenDanhMuc.Contains(searchString) || x.TenDanhMuc.Contains(searchString));
            }
            return model.OrderBy(x => x.MaDanhMuc).ToPagedList(page, pageSize);
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

        public bool Update(DanhMucKhoaHoc entity)
        {
            try
            {
                var _danhMucKhoaHoc = _context.DanhMucKhoaHocs.Find(entity.MaDanhMuc);
                _danhMucKhoaHoc.TenDanhMuc = entity.TenDanhMuc;

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DanhMucKhoaHoc ViewDetails(int id)
        {
            return _context.DanhMucKhoaHocs.Find(id);
        }

        public bool Delete(int _maDanhMuc)
        {
            try
            {
                var _danhMuc = _context.DanhMucKhoaHocs.Find(_maDanhMuc);
                _context.DanhMucKhoaHocs.Remove(_danhMuc);
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

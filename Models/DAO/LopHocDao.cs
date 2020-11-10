using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class LopHocDao
    {
        private eCenterDbContext _context = null;
        
        public LopHocDao()
        {
            _context = new eCenterDbContext();
        }

        public int Insert(LopHoc entity)
        {
            _context.LopHocs.Add(entity);
            _context.SaveChanges();
            return entity.MaLopHoc;
        }

        public LopHoc GetById(string tenLopHoc)
        {
            return _context.LopHocs.SingleOrDefault(x => x.TenLopHoc == tenLopHoc);
        }

        public IEnumerable<LopHoc> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<LopHoc> model = _context.LopHocs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenLopHoc.Contains(searchString) || x.TenLopHoc.Contains(searchString));
            }

            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }

        public bool Update(LopHoc entity)
        {
            try
            {
                var _lopHoc = _context.LopHocs.Find(entity.MaLopHoc);
                _lopHoc.TenLopHoc = entity.TenLopHoc;
                _lopHoc.NgayBatDau = entity.NgayBatDau;
                _lopHoc.TinhTrang = entity.TinhTrang;
                _lopHoc.NgayKetThuc = entity.NgayKetThuc;
                
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LopHoc ViewDetail(int id)
        {
            return _context.LopHocs.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _lopHoc = _context.LopHocs.Find(id);
                _context.LopHocs.Remove(_lopHoc);
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

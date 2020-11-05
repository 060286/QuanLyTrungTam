using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class KhoaHocDao
    {
        public eCenterDbContext _context = null;

        // Constructor
        public KhoaHocDao()
        {
            _context = new eCenterDbContext();
        }

        // Khởi tạo thêm mới Giáo viên 
        // Tham số truyền vào : thực thể kiểu GiaoVien
        public int Insert(GiaoVien entity)
        {
            entity.NgayDangKy = DateTime.Now;   // Gán ngày đăng ký bằng thời điểm đăng ký hiện tại
            _context.GiaoViens.Add(entity);     // Gọi method add
            _context.SaveChanges();
            return entity.MaGiaoVien;
        }

        public KhoaHoc GetById(string tenKhoaHoc)
        {
            return _context.KhoaHocs.SingleOrDefault(x => x.TenKhoaHoc == tenKhoaHoc);
        }

        public IEnumerable<KhoaHoc> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<KhoaHoc> model = _context.KhoaHocs;
            if(string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKhoaHoc.Contains(searchString) || x.TenKhoaHoc.Contains(searchString));
            }
            return model;
        }

        public bool Update(KhoaHoc entity)
        {
            try
            {
                var _khoaHoc = _context.KhoaHocs.Find(entity.MaKhoaHoc);
                _khoaHoc.TenKhoaHoc = entity.TenKhoaHoc;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        
        public KhoaHoc ViewDetails(int id)
        {
            return _context.KhoaHocs.Find(id);
        }
    }
}

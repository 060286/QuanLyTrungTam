using Models.Framework;
using PagedList;
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
        public int Insert(KhoaHoc entity)
        {
            /*entity.NgayDangKy = DateTime.Now;*/   // Gán ngày đăng ký bằng thời điểm đăng ký hiện tại
            _context.KhoaHocs.Add(entity);     // Gọi method add
            _context.SaveChanges();
            return entity.MaKhoaHoc;
        }
        // THêm danh mục khóa học
        public int Insert(DanhMucKhoaHoc entity)
        {
            _context.DanhMucKhoaHocs.Add(entity);
            _context.SaveChanges();
            return entity.MaDanhMuc;
        }

        public List<KhoaHoc> ListAll()
        {
            return _context.KhoaHocs.ToList();
        }

        //public IEnumerable<KhoaHoc> GetKHList()
        //{
        //    return _context.KhoaHocs.Where(x => x.MaKhoaHoc >= 0).ToList();
        //}

        //public KhoaHoc SelectAll()
        //{
        //    return _context.KhoaHocs.ToArray(x => x.TinhTrang == true);
        //}

        public KhoaHoc GetById(string tenKhoaHoc)
        {
            return _context.KhoaHocs.SingleOrDefault(x => x.TenKhoaHoc == tenKhoaHoc);
        }

        public IEnumerable<KhoaHoc> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<KhoaHoc> model = _context.KhoaHocs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenKhoaHoc.Contains(searchString) || x.MaKhoaHoc.ToString().Contains(searchString));
            }

            return model.OrderBy(x => x.MaKhoaHoc).ToPagedList(page, pageSize);
        }

        //public IEnumerable<KhoaHoc> ListAllPagingDescending()
        // New
        public IEnumerable<KhoaHoc> ListAllPagingByQuatity(string searchString, int page,int pageSize)
        {
            IQueryable<KhoaHoc> model = _context.KhoaHocs;
            if(!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.SoLuong.ToString().Contains(searchString));

            }
            return model.OrderBy(x => x.MaKhoaHoc).ToPagedList(page, pageSize);
        }

        public IEnumerable<KhoaHoc> ListAllPagingByMoney(string searchString, int page, int pageSize)
        {
            IQueryable<KhoaHoc> model = _context.KhoaHocs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.GiaTien.ToString().Contains(searchString));

            }
            return model.OrderBy(x => x.MaKhoaHoc).ToPagedList(page, pageSize);
        }


        //1 = Còn chỗ : 0 Hết chỗ 
        public IEnumerable<KhoaHoc> ListAllPagingByStatus(string searchString, int page, int pageSize)
        {
            IQueryable<KhoaHoc> model = _context.KhoaHocs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TinhTrang.ToString().Contains(searchString));

            }
            return model.OrderBy(x => x.MaKhoaHoc).ToPagedList(page, pageSize);
        }

        public IEnumerable<KhoaHoc> ListAllPagingByOld(string searchString, int page, int pageSize)
        {
            IQueryable<KhoaHoc> model = _context.KhoaHocs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.LuaTuoiPhuHop.ToString().Contains(searchString));

            }
            return model.OrderBy(x => x.MaKhoaHoc).ToPagedList(page, pageSize);
        }

        public bool Update(KhoaHoc entity)
        {
            try
            {
                var _khoaHoc = _context.KhoaHocs.Find(entity.MaKhoaHoc);
                _khoaHoc.TenKhoaHoc = entity.TenKhoaHoc;
                _khoaHoc.TinhTrang = entity.TinhTrang;
                _khoaHoc.MoTa = entity.MoTa;
                _khoaHoc.SoTuan = entity.SoTuan;
                //_khoaHoc.MaHocVien = entity.MaHocVien;
                _khoaHoc.MaGiaoVien = entity.MaGiaoVien;
                _khoaHoc.MaDanhMuc = entity.MaDanhMuc;
                _khoaHoc.LuaTuoiPhuHop = entity.LuaTuoiPhuHop;
                _khoaHoc.SoLuong = entity.SoLuong;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        
        public KhoaHoc ViewDetail(int id)
        {
            return _context.KhoaHocs.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _khoaHoc = _context.KhoaHocs.Find(id);
                _context.KhoaHocs.Remove(_khoaHoc);
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

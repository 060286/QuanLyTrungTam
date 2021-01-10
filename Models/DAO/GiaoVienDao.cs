using Models.Framework;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System;

namespace Models
{
    public class GiaoVienDao
    {
        private eCenterDbContext  _context = null;

        public GiaoVienDao()
        {
            _context = new eCenterDbContext();
        }

        public int Insert(GiaoVien entity)
        {
            _context.GiaoViens.Add(entity);
            _context.SaveChanges();
            return entity.MaGiaoVien;
        }

        public int InsertTrinhDo(TrinhDo entity)
        {
            _context.TrinhDoes.Add(entity);
            _context.SaveChanges();
            return entity.MaTrinhDo;
        }

        public List<GiaoVien> ListAll()
        {
            return _context.GiaoViens.Where(x => x.TrangThai == true).ToList();
        }

        // Lấy danh sách giáo viên đã nghỉ việc
        public List<GiaoVien> GetListGiaoVienInactivity()
        {
            return _context.GiaoViens.Where(x => x.TrangThai == false).ToList();
        }

        // Lấy giáo viên theo Tên
        public GiaoVien GetById(string tenGiaoVien)
        {
            return _context.GiaoViens.SingleOrDefault(x=>x.TenGiaoVien == tenGiaoVien);
        }

        // Sắp xếp thứ tự tăng dần
        public IEnumerable<GiaoVien> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenGiaoVien.Contains(searchString) || x.TenGiaoVien.Contains(searchString));
            }

            return model.OrderBy(x=>x.MaGiaoVien).ToPagedList(page,pageSize);
        }

        // Sắp xeeps theo thứ tự giảm dần
        public IEnumerable<GiaoVien> ListAllOrderByDescending(/*string  searchString,*/int page,int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    model = model.Where(x => x.TenGiaoVien.Contains(searchString) || x.TenGiaoVien.Contains(searchString));
            //}
            return model.OrderByDescending(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }
        // Search by Gender
        public IEnumerable<GiaoVien> ListAllPagingByGender(string searchStringByGender, int page, int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            if(!string.IsNullOrEmpty(searchStringByGender))
            {
                model = model.Where(x => x.GioiTinh.Contains(searchStringByGender));
            }
            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page,pageSize);
        }

        public IEnumerable<GiaoVien> ListAllPagingByEmail(string searchStringByEmail, int page, int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            if (!string.IsNullOrEmpty(searchStringByEmail))
            {
                model = model.Where(x => x.Email.Contains(searchStringByEmail));
            }
            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }

        public IEnumerable<GiaoVien> ListAllPagingByPhoneNumber(string searchStringByPhoneNumber, int page, int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            if (!string.IsNullOrEmpty(searchStringByPhoneNumber))
            {
                model = model.Where(x => x.SDT.ToString().Contains(searchStringByPhoneNumber));
            }
            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }

        public IEnumerable<GiaoVien> ListAllPagingByBirthday(string searchStringByBirthday, int page, int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            if (!string.IsNullOrEmpty(searchStringByBirthday))
            {
                model = model.Where(x => x.NgaySinh.ToString().Contains(searchStringByBirthday));
            }
            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }


        public IEnumerable<GiaoVien> ListAllByAddress(string searchStringAddress, int page, int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            if (!string.IsNullOrEmpty(searchStringAddress))
            {
                model = model.Where(x => x.DiaChi.Contains(searchStringAddress));
            }
            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }

        
        public IEnumerable<GiaoVien> ListAllPagingBySalary(string searchSalary,int page, int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            if(!string.IsNullOrEmpty(searchSalary))
            {
                model = model.Where(x => x.MucLuong.ToString().Contains(searchSalary));
            }
            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }

        public IEnumerable<GiaoVien> ListAllPagingByStatus(string searchStatus,int page,int pageSize)
        {
           IQueryable<GiaoVien> model = _context.GiaoViens;
            if (!string.IsNullOrEmpty(searchStatus))
            {
                model = model.Where(x => x.TrangThai.ToString().Contains(searchStatus) == true);
            }

            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }

        public bool Update(GiaoVien entity)
        {
            try
            {
                var _giaoVien = _context.GiaoViens.Find(entity.MaGiaoVien);
                _giaoVien.TenGiaoVien = entity.TenGiaoVien;
                _giaoVien.GioiTinh = entity.GioiTinh;
                _giaoVien.HinhAnh = entity.HinhAnh;
                _giaoVien.NgaySinh = entity.NgaySinh;
                _giaoVien.Email = entity.Email;
                _giaoVien.SDT = entity.SDT;
                _giaoVien.GhiChu = entity.GhiChu;
                _giaoVien.DiaChi = entity.DiaChi;
                _giaoVien.QuocTich = entity.QuocTich;
                _giaoVien.TrangThai = entity.TrangThai;
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GiaoVien ViewDetail(int id)
        {
            return _context.GiaoViens.Find(id);
        }


        // Xóa thì chuyển trạng thái giáo viên = false
        public bool Delete(int id)
        {
            try
            {
                var _giaoVien = _context.GiaoViens.Find(id);
                _giaoVien.TrangThai = false;
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

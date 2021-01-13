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
    public class HocVienDao
    {
        private eCenterDbContext context = null;

        public HocVienDao()
        {
            context = new eCenterDbContext();
        }

        public IEnumerable<HocVien> ListAllPaging(string searchString,int page, int pageSize)
        {

            IQueryable<HocVien> model = context.HocViens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenHocVien.Contains(searchString) || x.TenHocVien.Contains(searchString));
            }

            return model.OrderBy(x => x.MaHocVien).ToPagedList(page, pageSize);
        }

        // This method find all id student in classmate
        public List<int?> ListStudentInClassMate(string SearchStringByClass, int page, int pageSize)
        {
            List<int?> listMaHocVien = new List<int?>();

            IQueryable<HoaDon> getListHocVien = context.HoaDons;
            getListHocVien = getListHocVien.Where(x => x.MaLopHoc == int.Parse(SearchStringByClass));   // Find class mate

            listMaHocVien = getListHocVien.Select(x => x.MaHocVien).ToList();

            return listMaHocVien;
        }

        //public IEnumerable<HocVien> testSearchByOld(string searchString, int page, int pageSize)
        //{

        //    IQueryable<HocVien> model = context.HocViens;
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        model = model.Where(int.Parse(DateTime.Now.Year) ) );
        //    }

        //    return model.OrderBy(x => x.MaHocVien).ToPagedList(page, pageSize);
        //}


        public IEnumerable<HocVien> testSearchByAddress(string searchStringByAddress, int page, int pageSize)
        {

            IQueryable<HocVien> model = context.HocViens;
            if (!string.IsNullOrEmpty(searchStringByAddress))
            {
                model = model.Where(x => x.DiaChi.Contains(searchStringByAddress));
            }

            return model.OrderBy(x => x.MaHocVien).ToPagedList(page, pageSize);
        }

        public IEnumerable<HocVien> testSearchByEmail(string searchStringByEmail, int page, int pageSize)
        {

            IQueryable<HocVien> model = context.HocViens;
            if (!string.IsNullOrEmpty(searchStringByEmail))
            {
                model = model.Where(x => x.Email.Contains(searchStringByEmail));
            }

            return model.OrderBy(x => x.MaHocVien).ToPagedList(page, pageSize);
        }

        public IEnumerable<HocVien> testSearchByPhoneNumber(string searchStringByPhoneNumber, int page, int pageSize)
        {

            IQueryable<HocVien> model = context.HocViens;
            if (!string.IsNullOrEmpty(searchStringByPhoneNumber))
            {
                model = model.Where(x => x.SDT.ToString().Contains(searchStringByPhoneNumber));
            }

            return model.OrderBy(x => x.MaHocVien).ToPagedList(page, pageSize);
        }

        public IEnumerable<HocVien> testSearchByGender(string searchStringByGender, int page, int pageSize)
        {

            IQueryable<HocVien> model = context.HocViens;
            if (!string.IsNullOrEmpty(searchStringByGender))
            {
                model = model.Where(x => x.GioiTinh.Contains(searchStringByGender));
            }

            return model.OrderBy(x => x.MaHocVien).ToPagedList(page, pageSize);
        }

        public IEnumerable<HocVien> testSearchByStatus(string searchStringByStatus, int page, int pageSize)
        {

            IQueryable<HocVien> model = context.HocViens;
            if (!string.IsNullOrEmpty(searchStringByStatus))
            {
                model = model.Where(x => x.TrangThai.ToString().Contains(searchStringByStatus));
            }

            return model.OrderBy(x => x.MaHocVien).ToPagedList(page, pageSize);
        }

        public List<HocVien> ListAll()
        {
            return context.HocViens.ToList();
        }

        public HocVien GetHocVienById(int id)
        {
            return context.HocViens.SingleOrDefault(x => x.MaHocVien == id);
        }

        public int Insert(HocVien entity)
        {
            entity.NgayDangKy = DateTime.Now;
            context.HocViens.Add(entity);
            context.SaveChanges();
            return entity.MaHocVien;
        }

        

        public HocVien ViewDetails(int id)
        {
            return context.HocViens.Find(id);
        }

        public bool Update(HocVien hocVien)
        {
            try
            {
                var _hocVien = context.HocViens.Find(hocVien.MaHocVien);
                _hocVien.TenHocVien = hocVien.TenHocVien;
                _hocVien.GioiTinh = hocVien.GioiTinh;
                _hocVien.SDT = hocVien.SDT;
                _hocVien.Email = hocVien.Email;
                _hocVien.DiaChi = hocVien.DiaChi;
                _hocVien.NgaySinh = hocVien.NgaySinh;
                _hocVien.GhiChu = hocVien.GhiChu;
                _hocVien.TrangThai = hocVien.TrangThai;
                _hocVien.Nguon = hocVien.Nguon;

                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int maGiaoVien)
        {
            try
            {
                var _hocVien = context.HocViens.Find(maGiaoVien);
                context.HocViens.Remove(_hocVien);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

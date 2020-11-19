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

        public GiaoVien GetById(string tenGiaoVien)
        {
            return _context.GiaoViens.SingleOrDefault(x=>x.TenGiaoVien == tenGiaoVien);
        }

        public IEnumerable<GiaoVien> ListAllPaging(string searchString,int page, int pageSize)
        {
            IQueryable<GiaoVien> model = _context.GiaoViens;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenGiaoVien.Contains(searchString) || x.TenGiaoVien.Contains(searchString));
            }

            return model.OrderBy(x=>x.MaGiaoVien).ToPagedList(page,pageSize);
        }

        public bool Update(GiaoVien entity)
        {
            try
            {
                var _giaoVien = _context.GiaoViens.Find(entity.MaGiaoVien);
                _giaoVien.TenGiaoVien = entity.TenGiaoVien;
                _giaoVien.GioiTinh = entity.GioiTinh;
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

        public bool Delete(int id)
        {
            try
            {
                var _giaoVien = _context.GiaoViens.Find(id);
                _context.GiaoViens.Remove(_giaoVien);
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

using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class HoaDonDao
    {
        private eCenterDbContext _context = null;

        public HoaDonDao()
        {
            _context = new eCenterDbContext();
        }


        public int Insert(HoaDon entity)
        {
            _context.HoaDons.Add(entity);
            _context.SaveChanges();
            return entity.MaHoaDon;
        }

        public HoaDon GetById(int maHoaDon)
        {
            return _context.HoaDons.SingleOrDefault(x => x.MaHoaDon == maHoaDon);
        }

        public IEnumerable<HoaDon> ListAllPaging(int searchString, int page, int pageSize)
        {
            IQueryable<HoaDon> model = _context.HoaDons;
            if (searchString >= 0)
            {
                model = model.Where(x => x.MaHoaDon == searchString );
            }

            return model.OrderBy(x => x.MaHoaDon).ToPagedList(page, pageSize);
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

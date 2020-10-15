using Models.Framework;
using System.Collections.Generic;
using System.Linq;
using PagedList;
using System;

namespace Models
{
    public class GiaoVienDao
    {
        // Context : Lớp ngữ cảnh kế thừa từ DBContext
        private eCenterDbContext  context = null;

        public GiaoVienDao()
        {
            // Khởi tạo ngữ cảnh 
            context = new eCenterDbContext();
        }

        // Method : Insert GiaoVien entity
        public int Insert(GiaoVien entity)
        {
            var ngayDangKy = DateTime.Now;
            entity.NgayDangKy = ngayDangKy;

            context.GiaoViens.Add(entity);
            context.SaveChanges();
            return entity.MaGiaoVien;
        }

        public GiaoVien GetById(string tenGiaoVien)
        {
            return context.GiaoViens.SingleOrDefault(x=>x.TenGiaoVien == tenGiaoVien);
        }

        public IEnumerable<GiaoVien> ListAllPaging(int page, int pageSize)
        {

            return context.GiaoViens.OrderBy(x=>x.MaGiaoVien).ToPagedList(page,pageSize);
        }

        public bool Update(GiaoVien entity)
        {
            try
            {
                var giaoVien = context.GiaoViens.Find(entity.MaGiaoVien);
                giaoVien.TenGiaoVien = entity.TenGiaoVien;
                giaoVien.GioiTinh = entity.GioiTinh;
                giaoVien.NgaySinh = entity.NgaySinh;
                giaoVien.Email = entity.Email;
                giaoVien.SDT = entity.SDT;
                giaoVien.GhiChu = entity.GhiChu;
                giaoVien.DiaChi = entity.DiaChi;
                giaoVien.QuocTich = entity.QuocTich;
                giaoVien.TrangThai = entity.TrangThai;
                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GiaoVien ViewDetail(int id)
        {
            return context.GiaoViens.Find(id); 
        }

        public bool Delete(int id)
        {
            try
            {
                var giaoVien = context.GiaoViens.Find(id);
                context.GiaoViens.Remove(giaoVien);
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

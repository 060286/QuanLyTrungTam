using Models.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GiaoVienDao
    {
        private eCenterDbContext  context = null;

        public GiaoVienDao()
        {
            context = new eCenterDbContext();
        }

        public List<GiaoVien> listAll()
        {
            var list = context.Database.SqlQuery<GiaoVien>("Sp_GiaoVien_ListAll").ToList();
            return list;
        }

        //public int Create(string tenGiaoVien, string gioiTinh, DateTime? ngaySinh, string email, int? sdt, string ghiChu, string diaChi, string quocTich, bool? trangThai)
        //{
        //    object[] parameters =
        //    {
        //        new SqlParameter("@TenGiaoVien",tenGiaoVien),
        //        new SqlParameter("@GioiTinh",gioiTinh),
        //        new SqlParameter("@NgaySinh",ngaySinh),
        //        new SqlParameter("@Email",email),
        //        new SqlParameter("@SDT", sdt),
        //        new SqlParameter("@GhiChu",ghiChu),
        //        new SqlParameter("@DiaChi",diaChi),
        //        new SqlParameter("@QuocTich",quocTich),
        //        new SqlParameter("@TrangThai", trangThai)
        //    };

        //    int result = context.Database.ExecuteSqlCommand("Sp_GiaoVien_Insert @TenGiaoVien , @GioiTinh, @NgaySinh, @Email, @SDT, @GhiChu, @DiaChi, @QuocTich, @TrangThai", parameters);

        //    return result;
        //}

        public int Insert(GiaoVien entity)
        {
            context.GiaoViens.Add(entity);
            context.SaveChanges();
            return entity.MaGiaoVien;
        }
    }
}

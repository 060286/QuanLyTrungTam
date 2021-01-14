using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class PhuHuynhDao
    {
        private eCenterDbContext _context = null;

        public PhuHuynhDao()
        {
            _context = new eCenterDbContext();
        }

        public int Insert(PhuHuynh entity)
        {
            _context.PhuHuynhs.Add(entity);
            _context.SaveChanges();
            return entity.MaPhuHuynh;
        }

        public IEnumerable<PhuHuynh> getTwoElementPH(int maHocVien)
        {
            return _context.PhuHuynhs.Where(x => x.MaHocVien == maHocVien);
        }

        //public PhuHuynh getParentByIdStudent(int id)
        //{
        //    return _context.PhuHuynhs.;
        //}

        //public List<int> InsertList(PhuHuynh[] entity)
        //{
        //    List<int> list = new List<int>();

        //    for(int i = 0; i < 2; i++)
        //    {
        //        _context.PhuHuynhs.Add(entity[i]);
        //        _context.SaveChanges();

        //        list = list.Add(entity[i].MaPhuHuynh);
        //    }
        //    return list;
        //}

        public bool Update(PhuHuynh entity)
        {
            try {
                var _entity = _context.PhuHuynhs.Find(entity.MaPhuHuynh);
                _entity.TenPhuHuynh = entity.TenPhuHuynh;
                _entity.SDT = entity.SDT;
                _entity.GioiTinh = entity.GioiTinh;
                _entity.DiaChi = entity.DiaChi;
                _entity.Email = entity.Email;
                _context.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<PhuHuynh> GetListParents(int id)
        {
            return _context.PhuHuynhs.Where(x => x.MaHocVien == id).ToList();
        }
    }
}

using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    class PhuHuynhDao
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
    }
}

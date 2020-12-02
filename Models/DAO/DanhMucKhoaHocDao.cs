using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DanhMucKhoaHocDao
    {
        eCenterDbContext _context = null;

        public DanhMucKhoaHocDao()
        {
            _context = new eCenterDbContext();
        }

        public List<DanhMucKhoaHoc> ListAll()
        {
            return _context.DanhMucKhoaHocs.ToList();
        }

    }
}

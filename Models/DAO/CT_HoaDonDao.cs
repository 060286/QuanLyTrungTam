using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CT_HoaDonDao
    {
        private eCenterDbContext _context = null;

        public CT_HoaDonDao()
        {
            _context = new eCenterDbContext();
        }

        public int Insert(CT_HoaDon ctHD)
        {
            _context.CT_HoaDon.Add(ctHD);
            _context.SaveChanges();
            return ctHD.MaHoaDon;
        }
    }
}

using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ThoiKhoaBieuDao
    {
        public eCenterDbContext _context = null;

        // Constructor
        public ThoiKhoaBieuDao()
        {
            _context = new eCenterDbContext();
        }


        public int Insert(ThoiKhoaBieu tkb)
        {
            _context.ThoiKhoaBieux.Add(tkb);
            _context.SaveChanges();
            return tkb.MaTKB;
        }
    }
}

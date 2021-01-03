using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class TrinhDoDao
    {
        eCenterDbContext _context = null;

        public TrinhDoDao()
        {
            _context = new eCenterDbContext();
        }

        public List<TrinhDo> ListAll()
        {
            return _context.TrinhDoes.ToList();
        }

        public List<TrinhDo> ListTopFive()
        {
            return _context.TrinhDoes.Where(x => x.MaTrinhDo <= 5).ToList();
        }

        public int Insert(TrinhDo entity)
        {
            _context.TrinhDoes.Add(entity);
            _context.SaveChanges();
            return entity.MaTrinhDo;    
        }

        public int getIdMax()
        {
            return _context.TrinhDoes.Max(x => x.MaTrinhDo);
        }
    }
}

using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.DAO
{
    public class TrinhDoDao
    {
        eCenterDbContext _context = null;

        public TrinhDoDao()
        {
            _context = new eCenterDbContext();
        }

        public IEnumerable<TrinhDo> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<TrinhDo> model = _context.TrinhDoes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenTrinhDo.Contains(searchString) || x.TenTrinhDo.Contains(searchString));
            }

            return model.OrderBy(x => x.MaTrinhDo).ToPagedList(page, pageSize);
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

        public TrinhDo ViewDetails(int id)
        {
            return _context.TrinhDoes.Find(id);
        }

        public bool Update(TrinhDo entity)
        {
            try
            {
                var _lopHoc = _context.TrinhDoes.Find(entity.MaTrinhDo);

                _lopHoc.TenTrinhDo = entity.TenTrinhDo;
                _lopHoc.GhiChu = entity.GhiChu;

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int maTrinhDo)
        {
          
            try
            {
                var _trinhDo = _context.TrinhDoes.Find(maTrinhDo);
                _context.TrinhDoes.Remove(_trinhDo);
                _trinhDo.TinhTrang = false;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}

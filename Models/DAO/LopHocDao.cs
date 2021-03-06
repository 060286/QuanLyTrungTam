﻿using Models.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class LopHocDao
    {
        private eCenterDbContext _context = null;
        
        public LopHocDao()
        {
            _context = new eCenterDbContext();
        }

        public int Insert(LopHoc entity)
        {
            _context.LopHocs.Add(entity);

            entity.MaLopHoc = idMax() + 1;

            _context.SaveChanges();
            return entity.MaLopHoc;
        }

        public int idMax()
        {
            return _context.LopHocs.Max(x => x.MaLopHoc);
        }

        public List<LopHoc> ListAll()
        {
            return _context.LopHocs.ToList();
        }

        public List<LopHoc> ListTop5()
        {
            return _context.LopHocs.Where(x => x.MaLopHoc <= 5).ToList();
        }

        public LopHoc GetById(string tenLopHoc)
        {
            return _context.LopHocs.SingleOrDefault(x => x.TenLopHoc == tenLopHoc);
        }

        public IEnumerable<LopHoc> GetClassByStatus(bool status)
        {
            IQueryable<LopHoc> model = _context.LopHocs;
            if(status == true)
            {
                model = model.Where(x => x.TinhTrang == true);
            }
            return model.OrderBy(x => x.MaLopHoc).ToList();
        }

        public IEnumerable<LopHoc> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<LopHoc> model = _context.LopHocs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.TenLopHoc.Contains(searchString) || x.TenLopHoc.Contains(searchString));
            }

            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }

        // Ngày bắt đầu
        //public IEnumerable<LopHoc> testSearchByStartDate(string searchStringStartDate, int page, int pageSize)
        //{
        //    IQueryable<LopHoc> model = _context.LopHocs;
        //    if (!string.IsNullOrEmpty(searchStringStartDate))
        //    {
        //        model = model.Where(x => x.NgayBatDau.ToString().Contains(searchStringStartDate));
        //    }

        //    return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        //}

        //public IEnumerable<LopHoc> testSearchByEndDate(string searchStringEndDate, int page, int pageSize)
        //{
        //    IQueryable<LopHoc> model = _context.LopHocs;
        //    if (!string.IsNullOrEmpty(searchStringEndDate))
        //    {
        //        model = model.Where(x => x.NgayKetThuc.ToString().Contains(searchStringEndDate));
        //    }

        //    return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        //}


        public IEnumerable<LopHoc> testSearchByStatus(string searchStringStatus, int page, int pageSize)
        {
            IQueryable<LopHoc> model = _context.LopHocs;
            if (!string.IsNullOrEmpty(searchStringStatus))
            {
                model = model.Where(x => x.TinhTrang.ToString().Contains(searchStringStatus));
            }

            return model.OrderBy(x => x.MaGiaoVien).ToPagedList(page, pageSize);
        }

        public bool Update(LopHoc entity)
        {
            try
            {
                var _lopHoc = _context.LopHocs.Find(entity.MaLopHoc);
                _lopHoc.TenLopHoc = entity.TenLopHoc;
                _lopHoc.TinhTrang = entity.TinhTrang;
            
                
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public LopHoc ViewDetail(int id)
        {
            return _context.LopHocs.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                var _lopHoc = _context.LopHocs.Find(id);
                //_context.LopHocs.Remove(_lopHoc);
                _lopHoc.TinhTrang = false;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class SanPhamController : ApiController
    {
        CSDLTestEntities db = new CSDLTestEntities();

        [HttpGet]
        public List<SanPham> GetAll()
        {
            return db.SanPhams.ToList();
        }

        [HttpGet]
        public List<SanPham> GetByMaDM(int madm)
        {
            return db.SanPhams.Where(x => x.MaDM == madm).ToList();
        }

        //[HttpGet]
        //public SanPham GetByID(int masp)
        //{
        //    return db.SanPhams.FirstOrDefault(x => x.MaSP == masp);
        //}

        [HttpGet]
        public List<SanPham> test(int masp)
        {
            return db.SanPhams.Where(x => x.MaSP >= masp).ToList();
        }

        [HttpPost]
        public bool AddNew(int masp, string tensp, int madm)
        {
            SanPham s = db.SanPhams.FirstOrDefault(x => x.MaSP == masp);
            if (s == null)
            {
                SanPham s1 = new SanPham();
                s1.MaSP = masp;
                s1.TenSP = tensp;
                s1.MaDM = madm;

                db.SanPhams.Add(s1);
                db.SaveChanges();

                return true;
            }
            return false;
        }

        [HttpPut]
        public bool Update(int masp, string tensp, int madm)
        {
            SanPham s = db.SanPhams.FirstOrDefault(x => x.MaSP == masp);
            if (s != null)
            {
                s.MaSP = masp;
                s.TenSP = tensp;
                s.MaDM = madm;

                db.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        public bool Delete(int masp)
        {
            SanPham s = db.SanPhams.FirstOrDefault(x => x.MaSP == masp);
            if(s != null)
            {
                db.SanPhams.Remove(s);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

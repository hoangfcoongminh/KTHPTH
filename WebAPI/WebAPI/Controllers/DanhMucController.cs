using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DanhMucController : ApiController
    {
        CSDLTestEntities db = new CSDLTestEntities();

        [HttpGet]
        public List<DanhMuc> GetAll()
        {
            return db.DanhMucs.ToList();
        }
    }
}

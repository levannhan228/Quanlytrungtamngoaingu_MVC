using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlytrungtamngoaingu.Models;
using PagedList;
using PagedList.Mvc;
namespace Quanlytrungtamngoaingu.Controllers
{
    public class GiangVienController : Controller
    {
        TTNNContext db = new TTNNContext();        // GET: GiangVien
        public ActionResult GiangVien(int? page)
        {

            //Tạo biến sản phẩm trên trang
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);

            return View(db.GiaoViens.ToList().OrderBy(n => n.Tengv).ToPagedList(pageNumber, pageSize));

        }

    }
}
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
    public class KhoaHocController : Controller
    {
        TTNNContext db = new TTNNContext();
        // GET: KhoaHoc

        public ActionResult KhoaHoc(int? page)
        {

            //Tạo biến sản phẩm trên trang
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);

            return View(db.KhoaHocs.ToList().OrderBy(n => n.Giaban).ToPagedList(pageNumber, pageSize));

        }
        public ViewResult ChiTietKhoaHoc(String Makh)
        {
            KhoaHoc khoahoc = db.KhoaHocs.SingleOrDefault(n => n.Makh == Makh);
            if (khoahoc == null)
            {
                //Trả về trang báo lỗi
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.TenNgonNgu = db.NgonNgus.Single(n => n.Mann == khoahoc.Mann).Tennn;
            ViewBag.GiangVien = db.GiaoViens.Single(n => n.Magv == khoahoc.Magv).Tengv;
            return View(khoahoc);
        }

    }
}
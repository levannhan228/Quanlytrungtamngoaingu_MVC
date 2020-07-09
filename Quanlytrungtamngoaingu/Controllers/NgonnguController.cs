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
    public class NgonnguController : Controller
    {
        // GET: Ngonngu
        TTNNContext db = new TTNNContext();
        public ViewResult ListNgonngu()
        {
            return View(db.NgonNgus.Distinct().ToList());        
           
        }
        public ViewResult KhoaHocTheoNgonNgu(string Mann, int? page)
        {
            //Truy xuất danh sach các quyển sách theo chủ đề           
            if (db.KhoaHocs.Where(d => d.Mann.Equals(Mann)).ToList().Count == 0)
            {
                ViewBag.NgonNgu = "Không có khóa học nào thuộc ngôn ngữ này";
            }
            //Tạo biến sản phẩm trên trang
            int pageSize = 6;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.KhoaHocs.Where(d => d.Mann.Equals(Mann)).ToList().OrderBy(n => n.Giaban).ToPagedList(pageNumber, pageSize));
        }

    }
}
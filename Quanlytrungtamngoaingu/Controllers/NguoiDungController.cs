using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlytrungtamngoaingu.Models;

namespace Quanlytrungtamngoaingu.Controllers
{
    public class NguoiDungController : Controller
    {
        TTNNContext db = new TTNNContext();
        // GET: Nguoidung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DangKy(HocVien hv)
        {
            var trungma = db.HocViens.Where(n => n.Taikhoan.Equals(hv.Taikhoan)).ToList();
            if (trungma.Count != 0)
            {
                ViewBag.TrungMa = "Tài khoản đã tồn tại";
                return View();
            }
            else
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.HocViens.Add(hv);
                //Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            Session.Remove("Taikhoan");
            Session.Remove("KhoaHoc"); //["KhoaHoc"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f.Get("username").ToString();// như nhau
            string sMatKhau = f.Get("pword").ToString();//như nhau
            HocVien hv = db.HocViens.SingleOrDefault(n => n.Taikhoan == sTaiKhoan && n.Matkhau == sMatKhau);
            if (hv != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công !";
                Session["Taikhoan"] = hv;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("Taikhoan");
            Session.Remove("KhoaHoc"); //["KhoaHoc"] = null;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult TuyenSinh()
        {
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
    }
}
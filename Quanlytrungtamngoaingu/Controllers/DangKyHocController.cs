using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quanlytrungtamngoaingu.Models;

namespace Quanlytrungtamngoaingu.Controllers
{
    public class DangKyHocController : Controller
    {
        TTNNContext db = new TTNNContext();
        // GET: ListDangKy
        public List<DangKyKH> DangKyKhoaHoc()
        {

            List<DangKyKH> lstDangKy = Session["KhoaHoc"] as List<DangKyKH>;
            if (lstDangKy == null)
            {
                //Nếu list dang ky chưa tồn tại mình tiến hành khởi tạo list giỏ hàng cũng như sessionGioHang
                lstDangKy = new List<DangKyKH>();
                Session["KhoaHoc"] = lstDangKy;
            }
            return lstDangKy;
        }
        //Dang Ky khoa hoc
        public ActionResult ThemKhoaHoc(string sMakh, string strURL)
        {
            //Kiểm tra đăng nhập
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            KhoaHoc khoahoc = db.KhoaHocs.SingleOrDefault(n => n.Makh == sMakh);
            if (khoahoc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy session giỏ hàng
            List<DangKyKH> lstKhoaHoc = DangKyKhoaHoc();
            //Kiểm tra sách đã tồn tại trong Seesion giỏ hàng chưa
            DangKyKH khoahocdk = lstKhoaHoc.Find(n => n.sMakh == sMakh);
            if (khoahocdk == null)
            {
                khoahocdk = new DangKyKH(sMakh);
                //Add sản phẩm mới thêm vào list
                lstKhoaHoc.Add(khoahocdk);
                return Redirect(strURL);
            }
            else
            {
                return Redirect(strURL);
            }

        }
        //Xóa giỏ hàng
        public ActionResult XoaKhoaHoc(string sMakh)
        {

            //Kiểm tra mã sản phẩm
            KhoaHoc khoahoc = db.KhoaHocs.SingleOrDefault(n => n.Makh == sMakh);
            //Nếu get sai mã sản phẩm sẽ trả về trang lỗi
            if (khoahoc == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng từ session["GioHang"]
            List<DangKyKH> lstKhoaHoc = DangKyKhoaHoc();
            DangKyKH lstdangky = lstKhoaHoc.SingleOrDefault(n => n.sMakh == sMakh);
            //Nếu tồn tại thì sữa số lượng
            if (khoahoc != null)
            {
                lstKhoaHoc.RemoveAll(n => n.sMakh == sMakh);

            }
            if (lstKhoaHoc.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("ListDangKy");
        }
        //Xây dựng trang giỏ hàng
        public ActionResult ListDangKy()
        {
            if (Session["KhoaHoc"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<DangKyKH> lstKhoahoc = DangKyKhoaHoc();
            return View(lstKhoahoc);
        }
        #region Đặt hàng
        //Xây dựng chức năng đặt hàng
        [HttpPost]
        public ActionResult DangKy()
        {
            //Kiểm tra đăng nhập
            if (Session["Taikhoan"] == null || Session["Taikhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            //Làm mới lít đăng ký            
            //Thêm đơn đặt hàng
            if (Session["KhoaHoc"] == null)
            {
                RedirectToAction("Index", "Home");
            }
            //Thêm đơn hàng
            List<DangKyKH> dkkh = DangKyKhoaHoc();
            HocVien hv = (HocVien)Session["TaiKhoan"];
            DangKyHoc dkh = new DangKyHoc();

            dkh.Mahv = hv.Mahv;
            dkh.Ngaydangky = DateTime.Now.ToString();

            db.DangKyHocs.Add(dkh);
            db.SaveChanges();

            int id = dkh.Madangky;
            //Thêm chi tiết đơn hàng
            foreach (var item in dkkh)
            {
                ChiTietDangKyHoc ctdkh = new ChiTietDangKyHoc();
                ctdkh.Madangky = id;
                ctdkh.Makh = item.sMakh;
                ctdkh.Giaban = item.iGiaban;
                db.ChiTietDangKyHocs.Add(ctdkh);
                db.SaveChanges();
            }
           
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}

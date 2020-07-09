using OfficeOpenXml;
using PagedList;
using Quanlytrungtamngoaingu.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Quanlytrungtamngoaingu.Controllers
{
    public class QuanLyKhoaHocController : Controller
    {
        #region view
        TTNNContext db = new TTNNContext();
        // GET: QuanLyKhoaHoc
        public ActionResult viewKhoaHoc(int? page)
        {
            int pageSize = 10;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);

            return View(db.KhoaHocs.ToList().OrderBy(n => n.Makh).ToPagedList(pageNumber, pageSize));

        }
        public ActionResult viewGiangVien(int? page)
        {
            int pageSize = 10;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.GiaoViens.ToList().OrderBy(n=>n.Magv).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult viewHocVien(int? page)
        {
            int pageSize = 10;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.HocViens.ToList().OrderBy(n => n.Mahv).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult viewNgonNgu(int? page)
        {
            int pageSize = 10;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.NgonNgus.ToList().OrderBy(n => n.Mann).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult viewChiTietDangKyHoc(int? page)
        {
            int pageSize = 10;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.ChiTietDangKyHocs.ToList().OrderBy(n => n.Madangky).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult viewDangKyHoc(int? page)
        {
            int pageSize = 10;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return View(db.DangKyHocs.ToList().OrderBy(n => n.Madangky).ToPagedList(pageNumber, pageSize));
        }
        #endregion
        #region create
        [HttpGet]
        public ActionResult themmoiKhoaHoc()
        {
            ViewBag.Magv = new SelectList(db.GiaoViens.ToList().OrderBy(n => n.Tengv), "Magv", "Tengv");
            ViewBag.Ngonngu = new SelectList(db.NgonNgus.ToList().OrderBy(n => n.Mann), "Mann", "Tennn");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult themmoiKhoaHoc(KhoaHoc khoahoc, HttpPostedFileBase fileUpload)
        {
            
            ViewBag.Magv = new SelectList(db.GiaoViens.ToList().OrderBy(n => n.Tengv), "Magv", "Tengv");
            ViewBag.Ngonngu = new SelectList(db.NgonNgus.ToList().OrderBy(n => n.Mann), "Mann", "Tennn");
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Hãy lựa chọn hình ảnh";
                
                return View();
            }
            var fileName = Path.GetFileName(fileUpload.FileName);
            var path = Path.Combine(Server.MapPath("~/images"), fileName);
            //if (System.IO.File.Exists(path))
            //{
            //    ViewBag.Thongbao = "Hình ảnh đã tồn tại";
            //}
            //else
            //{
               
            //}

            fileUpload.SaveAs(path);
            khoahoc.AnhBia = fileUpload.FileName;
            var trungma = db.KhoaHocs.Where(n => n.Makh.Equals(khoahoc.Makh)).ToList();
            if (trungma.Count != 0)
            {
                ViewBag.TrungMa = "Mã khóa học đã tồn tại";
                return View();
            }
            else
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.KhoaHocs.Add(khoahoc);
              //  Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult themmoiHocVien()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themmoiHocVien(HocVien hv) 
        {
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
        public ActionResult themmoiGiangVien()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult themmoiGiangVien(GiaoVien gv, HttpPostedFileBase fileUpload)
        {
            if (fileUpload == null)
            {
                ViewBag.ThongBao = "Hãy lựa chọn hình ảnh";
                return View();
            }
            var fileName = Path.GetFileName(fileUpload.FileName);
            var path = Path.Combine(Server.MapPath("~/images"), fileName);
            fileUpload.SaveAs(path);
            gv.images = fileUpload.FileName;
            var trungma = db.GiaoViens.Where(n => n.Magv.Equals(gv.Magv)).ToList();
            if (trungma.Count != 0)
            {
                ViewBag.TrungMa = "Mã giảng viên đã tồn tại";
                return View();
            }
            else
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.GiaoViens.Add(gv);
                //Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult themmoiNgonNgu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult themmoiNgonNgu(NgonNgu nn)
        {
            //if(nn == db.NgonNgus.ToList())
            var trungma = db.NgonNgus.Where(n => n.Mann.Equals(nn.Mann)).ToList();
            if (trungma.Count != 0)
            {
                ViewBag.TrungMa = "Mã ngôn ngữ đã tồn tại";
                return View();
            }
            else
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.NgonNgus.Add(nn);
                //Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        #endregion
        #region edit
        [HttpGet]
        public ActionResult editKhoaHoc(string Makh)
        {
            KhoaHoc kh = db.KhoaHocs.SingleOrDefault(n => n.Makh == Makh);
            ViewBag.GiangVien = new SelectList(db.GiaoViens.ToList().OrderBy(n => n.Magv), "Magv", "Tengv",kh.Magv);
            ViewBag.Ngonngu = new SelectList(db.NgonNgus.ToList().OrderBy(n => n.Mann), "Mann", "Tennn",kh.Mann);
            return View(kh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult editKhoaHoc(KhoaHoc khoahoc, HttpPostedFileBase fileUpload)
        {   
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.Entry(khoahoc).State = System.Data.Entity.EntityState.Modified;    
                //  Lưu vào csdl
                db.SaveChanges();
            }
            ViewBag.Magv = new SelectList(db.GiaoViens.ToList().OrderBy(n => n.Magv), "Magv", "Tengv", khoahoc.Magv);
            ViewBag.Ngonngu = new SelectList(db.NgonNgus.ToList().OrderBy(n => n.Mann), "Mann", "Tennn", khoahoc.Mann);
            return View();
        }
        [HttpGet]
        public ActionResult editHocVien(int Mahv)
        {
            HocVien hv = db.HocViens.SingleOrDefault(n => n.Mahv == Mahv);
            return View(hv);
        }
        [HttpPost]
        public ActionResult editHocVien(HocVien hv)
        {
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.Entry(hv).State = System.Data.Entity.EntityState.Modified;
                //  Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult editGiangVien(string Magv)
        {
            GiaoVien gv = db.GiaoViens.SingleOrDefault(n => n.Magv == Magv);
            return View(gv);
        }
        [HttpPost]
        public ActionResult editGiangVien(GiaoVien gv)
        {
           
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.Entry(gv).State = System.Data.Entity.EntityState.Modified;
                //  Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult editNgonNgu( string Mann)
        {
            NgonNgu nn = db.NgonNgus.SingleOrDefault(n => n.Mann == Mann);
            return View(nn);
        }
        [HttpPost]
        public ActionResult editNgonNgu(NgonNgu nn)
        {          

            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.Entry(nn).State = System.Data.Entity.EntityState.Modified;
                //  Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult editChiTietDangKyHoc (int Madangky)
        {
            ChiTietDangKyHoc ctdkh = db.ChiTietDangKyHocs.SingleOrDefault(n => n.Madangky == Madangky);
            return View(ctdkh);
        }
        [HttpPost]
        public ActionResult editChiTietDangKyHoc(ChiTietDangKyHoc ctdkh)
        {
        
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.Entry(ctdkh).State = System.Data.Entity.EntityState.Modified;
                //  Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult editDangKyHoc(int Madangky)
        {
            DangKyHoc dkh = db.DangKyHocs.SingleOrDefault(n => n.Madangky == Madangky);
            return View(dkh);
        }
        [HttpPost]
        public ActionResult editDangKyHoc(DangKyHoc dkh)
        {
            if (ModelState.IsValid)
            {
                //Chèn dữ liệu cho bảng khách hàng
                db.Entry(dkh).State = System.Data.Entity.EntityState.Modified;
                //  Lưu vào csdl
                db.SaveChanges();
            }
            return View();
        }
        #endregion
        #region search

        public ActionResult timKiemKhoaHoc(string Tenkh)
        {
            ViewBag.key = Tenkh;
            List<KhoaHoc> listKhoaHoc = db.KhoaHocs.Where(n => n.Tenkhoahoc.Contains(Tenkh)).ToList() ;
            return View(listKhoaHoc);
        }
        public ActionResult timKiemGiangVien(string Tengv)
        {
            ViewBag.key = Tengv;
            List<GiaoVien> listGiangVien = db.GiaoViens.Where(n => n.Tengv.Contains(Tengv)).ToList();
            return View(listGiangVien);
        }
        public ActionResult timKiemHocVien(string Hotenhv)
        {
            ViewBag.key = Hotenhv;
            List<HocVien> listHocVien = db.HocViens.Where(n => n.Hotenhv.Contains(Hotenhv)).ToList();
            return View(listHocVien);
        }
        #endregion
        #region delete
        
        [HttpGet]
        public ActionResult deleteKhoaHoc()
        {
            return View(db.KhoaHocs.ToList());

        }
        [HttpPost]
        public ActionResult deleteKhoaHoc(string Makh)
        {
            KhoaHoc kh = db.KhoaHocs.SingleOrDefault(n => n.Makh == Makh);
            if (kh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.KhoaHocs.Remove(kh);
            db.SaveChanges();
            return RedirectToAction("viewKhoaHoc");
        }
        [HttpGet]
        public ActionResult deleteGiangVien()
        {
            return View(db.GiaoViens.ToList());
           
        }
        [HttpPost]
        public ActionResult deleteGiangVien(string Magv)
        {
            GiaoVien gv = db.GiaoViens.Where(n => n.Magv == Magv).FirstOrDefault();
            if (gv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.GiaoViens.Remove(gv);
            db.SaveChanges();
            return RedirectToAction("viewGiangVien");
        }
        [HttpGet]
        public ActionResult deleteHocVien()
        {
            return View(db.HocViens.ToList());

        }
        [HttpPost]
        public ActionResult deleteHocVien(int Mahv)
        {
            HocVien hv = db.HocViens.SingleOrDefault(n => n.Mahv == Mahv);
            if (hv == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.HocViens.Remove(hv);
            db.SaveChanges();
            return RedirectToAction("viewHocVien");
        }
        [HttpGet]
        public ActionResult deleteNgonNgu()
        {
            return View(db.NgonNgus.ToList());

        }
        [HttpPost]
        public ActionResult deleteNgonNgu(string Mann)
        {
            NgonNgu nn = db.NgonNgus.SingleOrDefault(n => n.Mann == Mann);
            if (nn == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NgonNgus.Remove(nn);
            db.SaveChanges();
            return RedirectToAction("viewNgonngu");
        }
        [HttpGet]
        public ActionResult deleteDangKyHoc()
        {
            return View(db.DangKyHocs.ToList());

        }
        [HttpPost]
        public ActionResult deleteDangKyHoc(int Madangky)
        {
            DangKyHoc dkh = db.DangKyHocs.SingleOrDefault(n => n.Madangky == Madangky);
            if (dkh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DangKyHocs.Remove(dkh);
            db.SaveChanges();
            return RedirectToAction("viewDangKyHoc");
        }
        [HttpGet]
        public ActionResult deleteChiTietDangKyHoc()
        {
            return View(db.DangKyHocs.ToList());

        }
        [HttpPost]
        public ActionResult deleteChiTietDangKyHoc(int Madangky)
        {
            ChiTietDangKyHoc ctdkh = db.ChiTietDangKyHocs.SingleOrDefault(n => n.Madangky == Madangky);
            if (ctdkh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChiTietDangKyHocs.Remove(ctdkh);
            db.SaveChanges();
            return RedirectToAction("viewChiTietDangKyHoc");
        }
        #endregion
        #region dowload excel        
        public void DownloadExcelNgonNgu ()
        {
            List<NgonNgu> ngonngu = db.NgonNgus.OrderBy(n => n.Mann).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
                ws.Cells["A1"].Value = "Code by";
                ws.Cells["B1"].Value = "Lê Văn Nhân";

                ws.Cells["A2"].Value = "Trung tâm ";
                ws.Cells["B2"].Value = "Ngoại Ngữ";

                ws.Cells["A3"].Value = "Date";
                ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

                ws.Cells["A6"].Value = "Mã ngôn ngữ";
                ws.Cells["B6"].Value = "Tên ngôn ngữ";

            int rowStart = 7;
            foreach (var item in ngonngu)
                {
                    //if (item.Experience < 5)
                    //{
                    //    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                    //}

                    ws.Cells[string.Format("A{0}", rowStart)].Value = item.Mann;
                    ws.Cells[string.Format("B{0}", rowStart)].Value = item.Tennn;               
                    rowStart++;
                }
                ws.Cells["A:AZ"].AutoFitColumns();
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
                Response.BinaryWrite(pck.GetAsByteArray());
                Response.End();
            }
        public void DownloadExcelKhoaHoc()
        {
            List<KhoaHoc> khoahoc = db.KhoaHocs.OrderBy(n => n.Makh).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Code by";
            ws.Cells["B1"].Value = "Lê Văn Nhân";

            ws.Cells["A2"].Value = "Trung tâm ";
            ws.Cells["B2"].Value = "Ngoại Ngữ";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã khóa học";
            ws.Cells["B6"].Value = "Tên khóa học";
            ws.Cells["C6"].Value = "Học phí";
            ws.Cells["D6"].Value = "Mô tả";
            ws.Cells["E6"].Value = "Ảnh minh họa";
            ws.Cells["F6"].Value = "Thời gian học";
            ws.Cells["G6"].Value = "Sĩ số";
            ws.Cells["H6"].Value = "Mã ngông ngữ";
            ws.Cells["I6"].Value = "Mã giảng viên";

            int rowStart = 7;
            foreach (var item in khoahoc)
            {
                //if (item.Experience < 5)
                //{
                //    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                //}

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Makh;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Tenkhoahoc;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Giaban;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Mota;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.AnhBia;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Thoigianhoc;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Siso;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Mann;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Magv;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        public void DownloadExcelGiangVien()
        {
            List<GiaoVien> gv = db.GiaoViens.OrderBy(n => n.Magv).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Code by";
            ws.Cells["B1"].Value = "Lê Văn Nhân";

            ws.Cells["A2"].Value = "Trung tâm ";
            ws.Cells["B2"].Value = "Ngoại Ngữ";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã giảng viên";
            ws.Cells["B6"].Value = "Tên giảng viên";
            ws.Cells["C6"].Value = "Hình ảnh";
            ws.Cells["D6"].Value = "Địa chỉ";
            ws.Cells["E6"].Value = "Điện thoại";
            ws.Cells["F6"].Value = "Ngày sinh";
            ws.Cells["G6"].Value = "giới tính";   

            int rowStart = 7;
            foreach (var item in gv)
            {
                //if (item.Experience < 5)
                //{
                //    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                //}


                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Magv;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Tengv;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.images;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Diachigv;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Dienthoaigv;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Ngaysinhgv;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Gioitinh;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        public void DownloadExcelHocVien()
        {
            List<HocVien> hocvien = db.HocViens.OrderBy(n => n.Mahv).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Code by";
            ws.Cells["B1"].Value = "Lê Văn Nhân";

            ws.Cells["A2"].Value = "Trung tâm ";
            ws.Cells["B2"].Value = "Ngoại Ngữ";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã học viên";
            ws.Cells["B6"].Value = "Họ tên học viên";
            ws.Cells["C6"].Value = "Tài khoản";
            ws.Cells["D6"].Value = "Mật khẩu";
            ws.Cells["E6"].Value = "Email";
            ws.Cells["F6"].Value = "Địa chỉ";
            ws.Cells["G6"].Value = "Điện thoại";
            ws.Cells["H6"].Value = "Giới tính";
            ws.Cells["I6"].Value = "Ngày sinh";
            int rowStart = 7;
            foreach (var item in hocvien)
            {
                //if (item.Experience < 5)
                //{
                //    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                //}


                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Mahv;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Hotenhv;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Taikhoan;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Matkhau;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Email;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.Diachihv;
                ws.Cells[string.Format("G{0}", rowStart)].Value = item.Dienthoaihv;
                ws.Cells[string.Format("H{0}", rowStart)].Value = item.Gioitinh;
                ws.Cells[string.Format("I{0}", rowStart)].Value = item.Ngaysinh;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        public void DownloadExcelDangKyHoc()
        {
            List<DangKyHoc> dkh = db.DangKyHocs.OrderBy(n => n.Madangky).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Code by";
            ws.Cells["B1"].Value = "Lê Văn Nhân";

            ws.Cells["A2"].Value = "Trung tâm ";
            ws.Cells["B2"].Value = "Ngoại Ngữ";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã đăng ký ";
            ws.Cells["B6"].Value = "Đã thanh toán";
            ws.Cells["C6"].Value = "Ngày đăng ký";
            ws.Cells["D6"].Value = "Lịch học";
            ws.Cells["E6"].Value = "Mã học viên";
            int rowStart = 7;
            foreach (var item in dkh)
            {
                //if (item.Experience < 5)
                //{
                //    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                //}


                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Madangky;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Dathanhtoan;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Ngaydangky;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.Lichhoc;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.Mahv;
       
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        public void DownloadExcelChiTietDangKyHoc()
        {
            List<ChiTietDangKyHoc> ctdkh = db.ChiTietDangKyHocs.ToList().OrderBy(n => n.Madangky).ToList();
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Code by";
            ws.Cells["B1"].Value = "Lê Văn Nhân";

            ws.Cells["A2"].Value = "Trung tâm ";
            ws.Cells["B2"].Value = "Ngoại Ngữ";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMMM yyyy} at {0:H: mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Mã đăng ký";
            ws.Cells["B6"].Value = "Mã khách hàng";
            ws.Cells["C6"].Value = "Học phí";
            int rowStart = 7;
            foreach (var item in ctdkh)
            {
                //if (item.Experience < 5)
                //{
                //    ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    ws.Row(rowStart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                //}

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.Madangky;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.Makh;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.Giaban;
                rowStart++;
            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        #endregion
        #region import excel
        [HttpPost]
        public ActionResult ImportExcelNgonNgu(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    // DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string conn = ConfigurationManager.ConnectionStrings["TTNN"].ConnectionString;
                    SqlConnection con = new SqlConnection(conn);
                    var myexcel = ds.Tables[0].Rows[i][0].ToString();
                    var trungma = db.NgonNgus.Where(n => n.Mann.Equals(myexcel)).ToList();
                    if (trungma.Count != 0)
                    {
                        TempData["TrungMa"] = "Mã ngông ngữ đã tồn tại vui lòng kiểm tra lại file excel";
                        return RedirectToAction("viewNgonngu");
                    }
                    else
                    {
                        string query = "Insert into NgonNgu(Mann,Tennn) Values(N'" +
                    ds.Tables[0].Rows[i][0].ToString() + "',N'" + ds.Tables[0].Rows[i][1].ToString() + "')";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return RedirectToAction("viewNgonNgu");
        }
        public ActionResult ImportExcelKhoaHoc(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                      
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    // DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string conn = ConfigurationManager.ConnectionStrings["TTNN"].ConnectionString;
                    SqlConnection con = new SqlConnection(conn);
                    var myexcel = ds.Tables[0].Rows[i][0].ToString();
                    var trungma = db.KhoaHocs.Where(n => n.Makh.Equals(myexcel)).ToList();
                    if (trungma.Count != 0)
                    {
                        TempData["TrungMa"] = "Mã khóa học đã tồn tại vui lòng kiểm tra lại file excel";
                        return RedirectToAction("viewKhoaHoc");
                    }
                    else
                    {
                        string query = "Insert into KhoaHoc(Makh,Tenkhoahoc,Giaban,Mota,AnhBia,Thoigianhoc,Siso,Mann,Magv) Values(N'" +
                    ds.Tables[0].Rows[i][0].ToString() + "',N'" + ds.Tables[0].Rows[i][1].ToString() + "',N'" + ds.Tables[0].Rows[i][2].ToString() + "',N'" + ds.Tables[0].Rows[i][3].ToString() + "',N'" + ds.Tables[0].Rows[i][4].ToString() + "',N'" + ds.Tables[0].Rows[i][5].ToString() + "',N'" + ds.Tables[0].Rows[i][6].ToString() + "',N'" + ds.Tables[0].Rows[i][7].ToString() + "',N'" + ds.Tables[0].Rows[i][8].ToString() + "')";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return RedirectToAction("viewKhoaHoc");
        }
        public ActionResult ImportExcelHocVien(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    // DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string conn = ConfigurationManager.ConnectionStrings["TTNN"].ConnectionString;
                    SqlConnection con = new SqlConnection(conn);
                    var myexcel = ds.Tables[0].Rows[i][0].ToString();
                    var trungma = db.HocViens.Where(n => n.Mahv.Equals(myexcel)).ToList();
                    if (trungma.Count != 0)
                    {
                        TempData["TrungMa"] = "Mã học viên đã tồn tại vui lòng kiểm tra lại file excel";
                        return RedirectToAction("viewHocVien");
                    }
                    else
                    {
                        string query = "Insert into HocVien(Hotenhv,Taikhoan,Matkhau,Email,Diachihv,Dienthoaihv,GioiTinh,Ngaysinh) Values(N'" +
                    ds.Tables[0].Rows[i][0].ToString() + "',N'" + ds.Tables[0].Rows[i][1].ToString() + "',N'" + ds.Tables[0].Rows[i][2].ToString() + "',N'" + ds.Tables[0].Rows[i][3].ToString() + "',N'" + ds.Tables[0].Rows[i][4].ToString() + "',N'" + ds.Tables[0].Rows[i][5].ToString() + "',N'" + ds.Tables[0].Rows[i][6].ToString() + "',N'" + ds.Tables[0].Rows[i][7].ToString() + "')";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return RedirectToAction("viewHocVien");
        }    
        public ActionResult ImportExcelGiangVien(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(fileLocation);
                        

                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                    
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    // DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string conn = ConfigurationManager.ConnectionStrings["TTNN"].ConnectionString;
                    SqlConnection con = new SqlConnection(conn);
                    var myexcel = ds.Tables[0].Rows[i][0].ToString();
                    var trungma = db.GiaoViens.Where(n => n.Magv.Equals(myexcel)).ToList();
                    if (trungma.Count != 0)
                    {
                        TempData["TrungMa"] = "Mã giảng viên đã tồn tại vui lòng kiểm tra lại file excel";
                        return RedirectToAction("viewGiangVien");
                    }
                    else
                    {
                        string query = "Insert into GiaoVien(Magv,Tengv,images,Diachigv,Dienthoaigv,Ngaysinhgv,Gioitinh) Values(N'" +
                    ds.Tables[0].Rows[i][0].ToString() + "',N'" + ds.Tables[0].Rows[i][1].ToString() + "',N'" + ds.Tables[0].Rows[i][2].ToString() + "',N'" + ds.Tables[0].Rows[i][3].ToString() + "',N'" + ds.Tables[0].Rows[i][4].ToString() + "',N'" + ds.Tables[0].Rows[i][5].ToString() + "',N'" + ds.Tables[0].Rows[i][6].ToString() + "')";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return RedirectToAction("viewGiangVien");
        }
        public ActionResult ImportExcelDangKyHoc(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    // DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string conn = ConfigurationManager.ConnectionStrings["TTNN"].ConnectionString;
                    SqlConnection con = new SqlConnection(conn);
                    var myexcel = ds.Tables[0].Rows[i][0].ToString();
                    var trungma = db.DangKyHocs.Where(n => n.Madangky.Equals(myexcel)).ToList();
                    if (trungma.Count != 0)
                    {
                        TempData["TrungMa"] = "Mã đăng ký đã tồn tại vui lòng kiểm tra lại file excel";
                        return RedirectToAction("viewGiangVien");
                    }
                    else
                    {
                        string query = "Insert into DangKyHoc(Dathanhtoan,Ngaydangky,Lichhoc,Mahv) Values('" +
                    ds.Tables[0].Rows[i][0].ToString() + "',N'" + ds.Tables[0].Rows[i][1].ToString() + "',N'" + ds.Tables[0].Rows[i][2].ToString() + "',N'" + ds.Tables[0].Rows[i][3].ToString() + "')";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return RedirectToAction("viewDangKyHoc");
        }
        public ActionResult ImportExcelChiTietDangKyHoc(HttpPostedFileBase file)
        {
            DataSet ds = new DataSet();
            if (Request.Files["file"].ContentLength > 0)
            {
                string fileExtension = System.IO.Path.GetExtension(Request.Files["file"].FileName);

                if (fileExtension == ".xls" || fileExtension == ".xlsx")
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["file"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        System.IO.File.Delete(fileLocation);
                    }
                    Request.Files["file"].SaveAs(fileLocation);
                    string excelConnectionString = string.Empty;
                    excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                    fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    //connection String for xls file format.
                    if (fileExtension == ".xls")
                    {
                        excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    }
                    //connection String for xlsx file format.
                    else if (fileExtension == ".xlsx")
                    {
                        excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                        fileLocation + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    }
                    //Create Connection to Excel work book and add oledb namespace
                    OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);
                    excelConnection.Open();
                    DataTable dt = new DataTable();

                    dt = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    if (dt == null)
                    {
                        return null;
                    }

                    String[] excelSheets = new String[dt.Rows.Count];
                    int t = 0;
                    //excel data saves in temp file here.
                    foreach (DataRow row in dt.Rows)
                    {
                        excelSheets[t] = row["TABLE_NAME"].ToString();
                        t++;
                    }
                    OleDbConnection excelConnection1 = new OleDbConnection(excelConnectionString);


                    string query = string.Format("Select * from [{0}]", excelSheets[0]);
                    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, excelConnection1))
                    {
                        dataAdapter.Fill(ds);
                    }
                }
                if (fileExtension.ToString().ToLower().Equals(".xml"))
                {
                    string fileLocation = Server.MapPath("~/Content/") + Request.Files["FileUpload"].FileName;
                    if (System.IO.File.Exists(fileLocation))
                    {
                        System.IO.File.Delete(fileLocation);
                    }

                    Request.Files["FileUpload"].SaveAs(fileLocation);
                    XmlTextReader xmlreader = new XmlTextReader(fileLocation);
                    // DataSet ds = new DataSet();
                    ds.ReadXml(xmlreader);
                    xmlreader.Close();
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string conn = ConfigurationManager.ConnectionStrings["TTNN"].ConnectionString;
                    SqlConnection con = new SqlConnection(conn);
                    string query = "Insert into ChiTietDangKyHoc(Madangky,Makh,Giaban) Values('" +
                    ds.Tables[0].Rows[i][0].ToString() + "',N'" + ds.Tables[0].Rows[i][1].ToString() + "',N'" + ds.Tables[0].Rows[i][2].ToString() + "','" + ds.Tables[0].Rows[i][3].ToString() + "')";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return RedirectToAction("viewChiTietDangKyHoc");
        }
        #endregion
    }
}
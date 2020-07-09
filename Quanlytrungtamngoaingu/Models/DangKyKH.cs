using Quanlytrungtamngoaingu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlytrungtamngoaingu.Models
{
    public class DangKyKH
    {
        TTNNContext db = new TTNNContext();
        public string sMakh { get; set; }
        public string sTenkh { get; set; }
        public string sAnhBia { get; set; }
        public string sTengv { get; set; }
        public int iGiaban { set; get; }
        public string sChitiet { get; set; }

        //ham tao listdangky
        public DangKyKH(string Makh)
        {
            sMakh = Makh;
            KhoaHoc kh = db.KhoaHocs.SingleOrDefault(n => n.Makh == sMakh);
            GiaoVien gv = db.GiaoViens.Single(n => n.Magv == kh.Magv);
            sTenkh = kh.Tenkhoahoc;
            sAnhBia = kh.AnhBia;
            sTengv = gv.Tengv;
            sAnhBia = kh.AnhBia;
            iGiaban = Int32.Parse(kh.Giaban.ToString());
            sChitiet = kh.Mota;

        }
    }
}
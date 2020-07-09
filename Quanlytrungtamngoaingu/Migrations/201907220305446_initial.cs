namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDangKyHoc",
                c => new
                    {
                        Madangky = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Makh = c.String(maxLength: 10, fixedLength: true),
                        Giaban = c.Int(),
                    })
                .PrimaryKey(t => t.Madangky)
                .ForeignKey("dbo.KhoaHoc", t => t.Makh)
                .Index(t => t.Makh);
            
            CreateTable(
                "dbo.DangKyHoc",
                c => new
                    {
                        Madangky = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Makh = c.String(maxLength: 10, fixedLength: true),
                        Dathanhtoan = c.Int(),
                        Ngaydangky = c.String(maxLength: 50),
                        Lichhoc = c.String(maxLength: 50),
                        Mahv = c.Int(),
                    })
                .PrimaryKey(t => t.Madangky)
                .ForeignKey("dbo.HocVien", t => t.Mahv)
                .ForeignKey("dbo.KhoaHoc", t => t.Makh)
                .ForeignKey("dbo.ChiTietDangKyHoc", t => t.Madangky)
                .Index(t => t.Madangky)
                .Index(t => t.Makh)
                .Index(t => t.Mahv);
            
            CreateTable(
                "dbo.HocVien",
                c => new
                    {
                        Mahv = c.Int(nullable: false, identity: true),
                        Hotenhv = c.String(maxLength: 50),
                        Taikhoan = c.String(maxLength: 50),
                        Matkhau = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Diachihv = c.String(maxLength: 50),
                        Dienthoaihv = c.String(maxLength: 50),
                        Gioitinh = c.String(maxLength: 50),
                        Ngaysinh = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Mahv);
            
            CreateTable(
                "dbo.KhoaHoc",
                c => new
                    {
                        Makh = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Tenkhoahoc = c.String(maxLength: 50),
                        Giaban = c.Int(),
                        Mota = c.String(),
                        AnhBia = c.String(maxLength: 50),
                        Thoigianhoc = c.String(maxLength: 50),
                        Siso = c.Int(),
                        Mann = c.String(maxLength: 10, fixedLength: true),
                        Magv = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.Makh)
                .ForeignKey("dbo.GiaoVien", t => t.Magv)
                .ForeignKey("dbo.NgonNgu", t => t.Mann)
                .Index(t => t.Mann)
                .Index(t => t.Magv);
            
            CreateTable(
                "dbo.GiaoVien",
                c => new
                    {
                        Magv = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Tengv = c.String(maxLength: 50),
                        Diachigv = c.String(maxLength: 10, fixedLength: true),
                        Dienthoaigv = c.Int(),
                        Ngaysinhgv = c.String(maxLength: 50),
                        Gioitinh = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Magv);
            
            CreateTable(
                "dbo.NgonNgu",
                c => new
                    {
                        Mann = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Tennn = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Mann);
            
            CreateTable(
                "dbo.TrinhDo",
                c => new
                    {
                        Matd = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Mann = c.String(maxLength: 10, fixedLength: true),
                        Tentd = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Matd)
                .ForeignKey("dbo.NgonNgu", t => t.Mann)
                .Index(t => t.Mann);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DangKyHoc", "Madangky", "dbo.ChiTietDangKyHoc");
            DropForeignKey("dbo.TrinhDo", "Mann", "dbo.NgonNgu");
            DropForeignKey("dbo.KhoaHoc", "Mann", "dbo.NgonNgu");
            DropForeignKey("dbo.KhoaHoc", "Magv", "dbo.GiaoVien");
            DropForeignKey("dbo.DangKyHoc", "Makh", "dbo.KhoaHoc");
            DropForeignKey("dbo.ChiTietDangKyHoc", "Makh", "dbo.KhoaHoc");
            DropForeignKey("dbo.DangKyHoc", "Mahv", "dbo.HocVien");
            DropIndex("dbo.TrinhDo", new[] { "Mann" });
            DropIndex("dbo.KhoaHoc", new[] { "Magv" });
            DropIndex("dbo.KhoaHoc", new[] { "Mann" });
            DropIndex("dbo.DangKyHoc", new[] { "Mahv" });
            DropIndex("dbo.DangKyHoc", new[] { "Makh" });
            DropIndex("dbo.DangKyHoc", new[] { "Madangky" });
            DropIndex("dbo.ChiTietDangKyHoc", new[] { "Makh" });
            DropTable("dbo.TrinhDo");
            DropTable("dbo.NgonNgu");
            DropTable("dbo.GiaoVien");
            DropTable("dbo.KhoaHoc");
            DropTable("dbo.HocVien");
            DropTable("dbo.DangKyHoc");
            DropTable("dbo.ChiTietDangKyHoc");
        }
    }
}

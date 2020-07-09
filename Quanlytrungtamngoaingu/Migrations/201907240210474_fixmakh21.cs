namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixmakh21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DangKyHocChiTietDangKyHocs", "ChiTietDangKyHoc_Madangky", "dbo.ChiTietDangKyHoc");
            DropForeignKey("dbo.ChiTietDangKyHoc", "Makh", "dbo.KhoaHoc");
            DropIndex("dbo.ChiTietDangKyHoc", new[] { "Makh" });
            DropIndex("dbo.DangKyHocChiTietDangKyHocs", new[] { "ChiTietDangKyHoc_Madangky" });
            DropPrimaryKey("dbo.ChiTietDangKyHoc");
            DropPrimaryKey("dbo.DangKyHocChiTietDangKyHocs");
            AddColumn("dbo.DangKyHocChiTietDangKyHocs", "ChiTietDangKyHoc_Makh", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.ChiTietDangKyHoc", "Madangky", c => c.Int(nullable: false));
            AlterColumn("dbo.ChiTietDangKyHoc", "Makh", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AddPrimaryKey("dbo.ChiTietDangKyHoc", new[] { "Madangky", "Makh" });
            AddPrimaryKey("dbo.DangKyHocChiTietDangKyHocs", new[] { "DangKyHoc_Madangky", "ChiTietDangKyHoc_Madangky", "ChiTietDangKyHoc_Makh" });
            CreateIndex("dbo.ChiTietDangKyHoc", "Makh");
            CreateIndex("dbo.DangKyHocChiTietDangKyHocs", new[] { "ChiTietDangKyHoc_Madangky", "ChiTietDangKyHoc_Makh" });
            AddForeignKey("dbo.DangKyHocChiTietDangKyHocs", new[] { "ChiTietDangKyHoc_Madangky", "ChiTietDangKyHoc_Makh" }, "dbo.ChiTietDangKyHoc", new[] { "Madangky", "Makh" }, cascadeDelete: true);
            AddForeignKey("dbo.ChiTietDangKyHoc", "Makh", "dbo.KhoaHoc", "Makh", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietDangKyHoc", "Makh", "dbo.KhoaHoc");
            DropForeignKey("dbo.DangKyHocChiTietDangKyHocs", new[] { "ChiTietDangKyHoc_Madangky", "ChiTietDangKyHoc_Makh" }, "dbo.ChiTietDangKyHoc");
            DropIndex("dbo.DangKyHocChiTietDangKyHocs", new[] { "ChiTietDangKyHoc_Madangky", "ChiTietDangKyHoc_Makh" });
            DropIndex("dbo.ChiTietDangKyHoc", new[] { "Makh" });
            DropPrimaryKey("dbo.DangKyHocChiTietDangKyHocs");
            DropPrimaryKey("dbo.ChiTietDangKyHoc");
            AlterColumn("dbo.ChiTietDangKyHoc", "Makh", c => c.String(maxLength: 10, fixedLength: true));
            AlterColumn("dbo.ChiTietDangKyHoc", "Madangky", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.DangKyHocChiTietDangKyHocs", "ChiTietDangKyHoc_Makh");
            AddPrimaryKey("dbo.DangKyHocChiTietDangKyHocs", new[] { "DangKyHoc_Madangky", "ChiTietDangKyHoc_Madangky" });
            AddPrimaryKey("dbo.ChiTietDangKyHoc", "Madangky");
            CreateIndex("dbo.DangKyHocChiTietDangKyHocs", "ChiTietDangKyHoc_Madangky");
            CreateIndex("dbo.ChiTietDangKyHoc", "Makh");
            AddForeignKey("dbo.ChiTietDangKyHoc", "Makh", "dbo.KhoaHoc", "Makh");
            AddForeignKey("dbo.DangKyHocChiTietDangKyHocs", "ChiTietDangKyHoc_Madangky", "dbo.ChiTietDangKyHoc", "Madangky", cascadeDelete: true);
        }
    }
}

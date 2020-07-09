namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DangKyHoc", "Madangky", "dbo.ChiTietDangKyHoc");
            DropIndex("dbo.DangKyHoc", new[] { "Madangky" });
            DropPrimaryKey("dbo.ChiTietDangKyHoc");
            DropPrimaryKey("dbo.DangKyHoc");
            AlterColumn("dbo.ChiTietDangKyHoc", "Madangky", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DangKyHoc", "Madangky", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ChiTietDangKyHoc", "Madangky");
            AddPrimaryKey("dbo.DangKyHoc", "Madangky");
            CreateIndex("dbo.DangKyHoc", "Madangky");
            AddForeignKey("dbo.DangKyHoc", "Madangky", "dbo.ChiTietDangKyHoc", "Madangky");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DangKyHoc", "Madangky", "dbo.ChiTietDangKyHoc");
            DropIndex("dbo.DangKyHoc", new[] { "Madangky" });
            DropPrimaryKey("dbo.DangKyHoc");
            DropPrimaryKey("dbo.ChiTietDangKyHoc");
            AlterColumn("dbo.DangKyHoc", "Madangky", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AlterColumn("dbo.ChiTietDangKyHoc", "Madangky", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
            AddPrimaryKey("dbo.DangKyHoc", "Madangky");
            AddPrimaryKey("dbo.ChiTietDangKyHoc", "Madangky");
            CreateIndex("dbo.DangKyHoc", "Madangky");
            AddForeignKey("dbo.DangKyHoc", "Madangky", "dbo.ChiTietDangKyHoc", "Madangky");
        }
    }
}

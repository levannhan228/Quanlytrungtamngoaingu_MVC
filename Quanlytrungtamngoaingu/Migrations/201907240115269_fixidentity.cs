namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixidentity : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DangKyHoc", new[] { "Madangky" });
            DropPrimaryKey("dbo.DangKyHoc");
            AlterColumn("dbo.DangKyHoc", "Madangky", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.DangKyHoc", "Madangky");
            CreateIndex("dbo.DangKyHoc", "Madangky");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DangKyHoc", new[] { "Madangky" });
            DropPrimaryKey("dbo.DangKyHoc");
            AlterColumn("dbo.DangKyHoc", "Madangky", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DangKyHoc", "Madangky");
            CreateIndex("dbo.DangKyHoc", "Madangky");
        }
    }
}

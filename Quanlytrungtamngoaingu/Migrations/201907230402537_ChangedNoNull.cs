namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNoNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HocVien", "Hotenhv", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HocVien", "Taikhoan", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HocVien", "Matkhau", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HocVien", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HocVien", "Diachihv", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HocVien", "Dienthoaihv", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HocVien", "Gioitinh", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.HocVien", "Ngaysinh", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HocVien", "Ngaysinh", c => c.String(maxLength: 50));
            AlterColumn("dbo.HocVien", "Gioitinh", c => c.String(maxLength: 50));
            AlterColumn("dbo.HocVien", "Dienthoaihv", c => c.String(maxLength: 50));
            AlterColumn("dbo.HocVien", "Diachihv", c => c.String(maxLength: 50));
            AlterColumn("dbo.HocVien", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.HocVien", "Matkhau", c => c.String(maxLength: 50));
            AlterColumn("dbo.HocVien", "Taikhoan", c => c.String(maxLength: 50));
            AlterColumn("dbo.HocVien", "Hotenhv", c => c.String(maxLength: 50));
        }
    }
}

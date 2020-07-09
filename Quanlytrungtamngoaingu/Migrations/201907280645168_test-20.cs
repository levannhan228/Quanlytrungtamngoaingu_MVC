namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GiaoVien", "Diachigv", c => c.String(nullable: false, maxLength: 50, fixedLength: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GiaoVien", "Diachigv", c => c.String(nullable: false, maxLength: 10, fixedLength: true));
        }
    }
}

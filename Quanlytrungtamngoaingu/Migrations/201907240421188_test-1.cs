namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhoaHoc", "AnhBia", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhoaHoc", "AnhBia", c => c.String(unicode: false));
        }
    }
}

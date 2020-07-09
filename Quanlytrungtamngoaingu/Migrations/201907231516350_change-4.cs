namespace Quanlytrungtamngoaingu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.NgonNgu", "Tennn", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.NgonNgu", "Tennn", c => c.String(maxLength: 50));
        }
    }
}

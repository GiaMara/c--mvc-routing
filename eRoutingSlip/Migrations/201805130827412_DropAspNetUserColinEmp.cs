namespace eRoutingSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAspNetUserColinEmp : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "AspNetUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "AspNetUserId", c => c.String());
        }
    }
}

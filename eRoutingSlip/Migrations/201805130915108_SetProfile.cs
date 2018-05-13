namespace eRoutingSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "JobTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "JobTitle");
        }
    }
}

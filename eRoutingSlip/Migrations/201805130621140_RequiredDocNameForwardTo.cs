namespace eRoutingSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredDocNameForwardTo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoutingSlips", "DocumentName", c => c.String(nullable: false));
            AlterColumn("dbo.RoutingSlips", "ForwardTo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoutingSlips", "ForwardTo", c => c.String());
            AlterColumn("dbo.RoutingSlips", "DocumentName", c => c.String());
        }
    }
}

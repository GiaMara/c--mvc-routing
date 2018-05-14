namespace eRoutingSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DivIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RoutingSlips", "DivisionID", "dbo.Divisions");
            DropIndex("dbo.RoutingSlips", new[] { "DivisionID" });
            AlterColumn("dbo.RoutingSlips", "DivisionID", c => c.Int());
            CreateIndex("dbo.RoutingSlips", "DivisionID");
            AddForeignKey("dbo.RoutingSlips", "DivisionID", "dbo.Divisions", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoutingSlips", "DivisionID", "dbo.Divisions");
            DropIndex("dbo.RoutingSlips", new[] { "DivisionID" });
            AlterColumn("dbo.RoutingSlips", "DivisionID", c => c.Int(nullable: false));
            CreateIndex("dbo.RoutingSlips", "DivisionID");
            AddForeignKey("dbo.RoutingSlips", "DivisionID", "dbo.Divisions", "ID", cascadeDelete: true);
        }
    }
}

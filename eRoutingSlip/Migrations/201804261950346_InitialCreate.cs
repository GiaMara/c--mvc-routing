namespace eRoutingSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DivisionName = c.String(),
                        DivisionHead = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoutingSlips",
                c => new
                    {
                        RoutingSlipID = c.Int(nullable: false, identity: true),
                        DocumentName = c.String(),
                        RequestingEmployee = c.String(),
                        DateSubmitted = c.DateTime(nullable: false),
                        ForwardTo = c.String(),
                        DivisionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoutingSlipID)
                .ForeignKey("dbo.Divisions", t => t.DivisionID, cascadeDelete: true)
                .Index(t => t.DivisionID);
            
            CreateTable(
                "dbo.Signatures",
                c => new
                    {
                        SignatureID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateRouted = c.DateTime(nullable: false),
                        Response = c.String(),
                        RoutingSlipID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SignatureID)
                .ForeignKey("dbo.RoutingSlips", t => t.RoutingSlipID, cascadeDelete: true)
                .Index(t => t.RoutingSlipID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoutingSlips", "DivisionID", "dbo.Divisions");
            DropForeignKey("dbo.Signatures", "RoutingSlipID", "dbo.RoutingSlips");
            DropIndex("dbo.Signatures", new[] { "RoutingSlipID" });
            DropIndex("dbo.RoutingSlips", new[] { "DivisionID" });
            DropTable("dbo.Signatures");
            DropTable("dbo.RoutingSlips");
            DropTable("dbo.Divisions");
        }
    }
}

namespace eRoutingSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
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
                        LinkedListSignature_ID = c.Int(),
                    })
                .PrimaryKey(t => t.RoutingSlipID)
                .ForeignKey("dbo.LinkedListSignatures", t => t.LinkedListSignature_ID)
                .ForeignKey("dbo.Divisions", t => t.DivisionID, cascadeDelete: true)
                .Index(t => t.DivisionID)
                .Index(t => t.LinkedListSignature_ID);
            
            CreateTable(
                "dbo.LinkedListSignatures",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoutingSlipID = c.Int(nullable: false),
                        CurrentName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LinkedListSignatureNodes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoutingSlipID = c.Int(nullable: false),
                        Data_SignatureID = c.Int(),
                        PreviousNodeId = c.Int(),
                        PrevSNode_ID = c.Int(),
                        LinkedListSignature_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Signatures", t => t.Data_SignatureID)
                .ForeignKey("dbo.LinkedListSignatureNodes", t => t.PreviousNodeId)
                .ForeignKey("dbo.LinkedListSignatureNodes", t => t.PrevSNode_ID)
                .ForeignKey("dbo.LinkedListSignatures", t => t.LinkedListSignature_ID)
                .Index(t => t.Data_SignatureID)
                .Index(t => t.PreviousNodeId)
                .Index(t => t.PrevSNode_ID)
                .Index(t => t.LinkedListSignature_ID);
            
            CreateTable(
                "dbo.Signatures",
                c => new
                    {
                        SignatureID = c.Int(nullable: false, identity: true),
                        SignatureName = c.String(),
                        DateRouted = c.DateTime(nullable: false),
                        Status = c.String(),
                        RoutingSlipID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SignatureID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoutingSlips", "DivisionID", "dbo.Divisions");
            DropForeignKey("dbo.RoutingSlips", "LinkedListSignature_ID", "dbo.LinkedListSignatures");
            DropForeignKey("dbo.LinkedListSignatureNodes", "LinkedListSignature_ID", "dbo.LinkedListSignatures");
            DropForeignKey("dbo.LinkedListSignatureNodes", "PrevSNode_ID", "dbo.LinkedListSignatureNodes");
            DropForeignKey("dbo.LinkedListSignatureNodes", "PreviousNodeId", "dbo.LinkedListSignatureNodes");
            DropForeignKey("dbo.LinkedListSignatureNodes", "Data_SignatureID", "dbo.Signatures");
            DropIndex("dbo.LinkedListSignatureNodes", new[] { "LinkedListSignature_ID" });
            DropIndex("dbo.LinkedListSignatureNodes", new[] { "PrevSNode_ID" });
            DropIndex("dbo.LinkedListSignatureNodes", new[] { "PreviousNodeId" });
            DropIndex("dbo.LinkedListSignatureNodes", new[] { "Data_SignatureID" });
            DropIndex("dbo.RoutingSlips", new[] { "LinkedListSignature_ID" });
            DropIndex("dbo.RoutingSlips", new[] { "DivisionID" });
            DropTable("dbo.Signatures");
            DropTable("dbo.LinkedListSignatureNodes");
            DropTable("dbo.LinkedListSignatures");
            DropTable("dbo.RoutingSlips");
            DropTable("dbo.Divisions");
        }
    }
}

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
                        NextSNode_ID = c.Int(),
                        PrevSNode_ID = c.Int(),
                        LinkedListSignature_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Signatures", t => t.Data_SignatureID)
                .ForeignKey("dbo.LinkedListSignatureNodes", t => t.NextSNode_ID)
                .ForeignKey("dbo.LinkedListSignatureNodes", t => t.PrevSNode_ID)
                .ForeignKey("dbo.LinkedListSignatures", t => t.LinkedListSignature_ID)
                .Index(t => t.Data_SignatureID)
                .Index(t => t.NextSNode_ID)
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RoutingSlips", "DivisionID", "dbo.Divisions");
            DropForeignKey("dbo.RoutingSlips", "LinkedListSignature_ID", "dbo.LinkedListSignatures");
            DropForeignKey("dbo.LinkedListSignatureNodes", "LinkedListSignature_ID", "dbo.LinkedListSignatures");
            DropForeignKey("dbo.LinkedListSignatureNodes", "PrevSNode_ID", "dbo.LinkedListSignatureNodes");
            DropForeignKey("dbo.LinkedListSignatureNodes", "NextSNode_ID", "dbo.LinkedListSignatureNodes");
            DropForeignKey("dbo.LinkedListSignatureNodes", "Data_SignatureID", "dbo.Signatures");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LinkedListSignatureNodes", new[] { "LinkedListSignature_ID" });
            DropIndex("dbo.LinkedListSignatureNodes", new[] { "PrevSNode_ID" });
            DropIndex("dbo.LinkedListSignatureNodes", new[] { "NextSNode_ID" });
            DropIndex("dbo.LinkedListSignatureNodes", new[] { "Data_SignatureID" });
            DropIndex("dbo.RoutingSlips", new[] { "LinkedListSignature_ID" });
            DropIndex("dbo.RoutingSlips", new[] { "DivisionID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Signatures");
            DropTable("dbo.LinkedListSignatureNodes");
            DropTable("dbo.LinkedListSignatures");
            DropTable("dbo.RoutingSlips");
            DropTable("dbo.Divisions");
        }
    }
}

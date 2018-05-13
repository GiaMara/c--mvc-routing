namespace eRoutingSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeesERSDBandIdentityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        DivisionId = c.Int(nullable: false),
                        AspNetUserId = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}

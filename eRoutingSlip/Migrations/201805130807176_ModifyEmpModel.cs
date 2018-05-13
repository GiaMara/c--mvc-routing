namespace eRoutingSlip.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyEmpModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "ID");
            AddColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Employees");
            DropColumn("dbo.Employees", "EmployeeID");
            AddPrimaryKey("dbo.Employees", "ID");
        }
    }
}

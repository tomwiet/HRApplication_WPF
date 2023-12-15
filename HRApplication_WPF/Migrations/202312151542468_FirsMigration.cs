namespace HRApplication_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirsMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirsName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Earnings = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmploymentPeriods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        EmploymentDate = c.DateTime(nullable: false),
                        DismissalDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmploymentPeriodEmployees",
                c => new
                    {
                        EmploymentPeriod_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmploymentPeriod_Id, t.Employee_Id })
                .ForeignKey("dbo.EmploymentPeriods", t => t.EmploymentPeriod_Id, cascadeDelete: true)
                .ForeignKey("dbo.Employes", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.EmploymentPeriod_Id)
                .Index(t => t.Employee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmploymentPeriodEmployees", "Employee_Id", "dbo.Employes");
            DropForeignKey("dbo.EmploymentPeriodEmployees", "EmploymentPeriod_Id", "dbo.EmploymentPeriods");
            DropIndex("dbo.EmploymentPeriodEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.EmploymentPeriodEmployees", new[] { "EmploymentPeriod_Id" });
            DropTable("dbo.EmploymentPeriodEmployees");
            DropTable("dbo.EmploymentPeriods");
            DropTable("dbo.Employes");
        }
    }
}

namespace HRApplication_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmploymentPeriodEmployees", "EmploymentPeriod_Id", "dbo.EmploymentPeriods");
            DropForeignKey("dbo.EmploymentPeriodEmployees", "Employee_Id", "dbo.Employes");
            DropIndex("dbo.EmploymentPeriodEmployees", new[] { "EmploymentPeriod_Id" });
            DropIndex("dbo.EmploymentPeriodEmployees", new[] { "Employee_Id" });
            CreateIndex("dbo.EmploymentPeriods", "EmployeeId");
            AddForeignKey("dbo.EmploymentPeriods", "EmployeeId", "dbo.Employes", "Id", cascadeDelete: true);
            DropTable("dbo.EmploymentPeriodEmployees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmploymentPeriodEmployees",
                c => new
                    {
                        EmploymentPeriod_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmploymentPeriod_Id, t.Employee_Id });
            
            DropForeignKey("dbo.EmploymentPeriods", "EmployeeId", "dbo.Employes");
            DropIndex("dbo.EmploymentPeriods", new[] { "EmployeeId" });
            CreateIndex("dbo.EmploymentPeriodEmployees", "Employee_Id");
            CreateIndex("dbo.EmploymentPeriodEmployees", "EmploymentPeriod_Id");
            AddForeignKey("dbo.EmploymentPeriodEmployees", "Employee_Id", "dbo.Employes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmploymentPeriodEmployees", "EmploymentPeriod_Id", "dbo.EmploymentPeriods", "Id", cascadeDelete: true);
        }
    }
}

namespace HRApplication_WPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetDismisstimeToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmploymentPeriods", "DismissalDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmploymentPeriods", "DismissalDate", c => c.DateTime(nullable: false));
        }
    }
}

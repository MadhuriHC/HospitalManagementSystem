namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTreatmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "CheckupDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Treatments", "Medicine", c => c.String(nullable: false));
            AddColumn("dbo.Treatments", "Doses", c => c.String(nullable: false));
            AddColumn("dbo.Treatments", "BeforeMeal", c => c.String(nullable: false));
            DropColumn("dbo.Treatments", "Prescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Treatments", "Prescription", c => c.String(nullable: false));
            DropColumn("dbo.Treatments", "BeforeMeal");
            DropColumn("dbo.Treatments", "Doses");
            DropColumn("dbo.Treatments", "Medicine");
            DropColumn("dbo.Treatments", "CheckupDate");
        }
    }
}

namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTreatmentTable2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Treatments");
            DropColumn("dbo.Treatments", "TreatemntID");
            AddColumn("dbo.Treatments", "TreatmentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Treatments", "TreatmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Treatments", "TreatemntID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Treatments", "TreatemntID");
            DropPrimaryKey("dbo.Treatments");
            DropColumn("dbo.Treatments", "TreatmentID");
        }
    }
}

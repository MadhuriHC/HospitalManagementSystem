namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTreatmentTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Treatments", "Advice", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Treatments", "Advice");
        }
    }
}

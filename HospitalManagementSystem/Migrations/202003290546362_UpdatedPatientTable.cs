namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPatientTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Gender");
        }
    }
}

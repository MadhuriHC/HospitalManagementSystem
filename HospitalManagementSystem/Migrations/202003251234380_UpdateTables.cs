namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Treatments",
                c => new
                    {
                        TreatemntID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(),
                        Symptoms = c.String(nullable: false),
                        Diagnosis = c.String(nullable: false),
                        Prescription = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TreatemntID)
                .ForeignKey("dbo.Patients", t => t.PatientID)
                .Index(t => t.PatientID);
            
            AddColumn("dbo.Patients", "DoctorID", c => c.Int());
            CreateIndex("dbo.Patients", "DoctorID");
            AddForeignKey("dbo.Patients", "DoctorID", "dbo.Doctors", "DoctorID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Treatments", "PatientID", "dbo.Patients");
            DropForeignKey("dbo.Patients", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.Treatments", new[] { "PatientID" });
            DropIndex("dbo.Patients", new[] { "DoctorID" });
            DropColumn("dbo.Patients", "DoctorID");
            DropTable("dbo.Treatments");
        }
    }
}

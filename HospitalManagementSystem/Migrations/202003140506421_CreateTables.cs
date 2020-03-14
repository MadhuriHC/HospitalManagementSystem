namespace HMSProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperAdmins",
                c => new
                    {
                        SID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Phone = c.Long(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorID);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(),
                        Phone = c.Long(nullable: false),
                        BloodGroup = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.Long(nullable: false),
                        SCategory = c.String(),
                    })
                .PrimaryKey(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.SuperAdmins");
        }
    }
}

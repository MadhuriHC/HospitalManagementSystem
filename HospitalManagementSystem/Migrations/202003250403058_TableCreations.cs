namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableCreations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SuperAdmins",
                c => new
                    {
                        SID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Phone = c.Long(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SID);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Long(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorID);
            
            CreateTable(
                "dbo.GuestResponses",
                c => new
                    {
                        inputId = c.Int(nullable: false, identity: true),
                        inputFName = c.String(nullable: false),
                        inputLName = c.String(nullable: false),
                        inputPassword = c.String(nullable: false),
                        inputPhone = c.String(nullable: false),
                        inputEmail = c.String(nullable: false),
                        inputType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.inputId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Long(nullable: false),
                        BloodGroup = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.PatientID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Long(nullable: false),
                        SCategory = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StaffID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Staffs");
            DropTable("dbo.Patients");
            DropTable("dbo.GuestResponses");
            DropTable("dbo.Doctors");
            DropTable("dbo.SuperAdmins");
        }
    }
}

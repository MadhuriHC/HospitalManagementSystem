namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRegistrationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false, maxLength: 30),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
            DropTable("dbo.GuestResponses");
        }
        
        public override void Down()
        {
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
            
            DropTable("dbo.Registrations");
        }
    }
}

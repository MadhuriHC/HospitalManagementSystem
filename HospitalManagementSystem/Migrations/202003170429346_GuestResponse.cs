namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuestResponse : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GuestResponses");
        }
    }
}

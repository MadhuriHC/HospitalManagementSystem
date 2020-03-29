namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePaymentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymemntID = c.Int(nullable: false, identity: true),
                        PatientID = c.Int(),
                        PayableAmount = c.Double(nullable: false),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PaymemntID)
                .ForeignKey("dbo.Patients", t => t.PatientID)
                .Index(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PatientID", "dbo.Patients");
            DropIndex("dbo.Payments", new[] { "PatientID" });
            DropTable("dbo.Payments");
        }
    }
}

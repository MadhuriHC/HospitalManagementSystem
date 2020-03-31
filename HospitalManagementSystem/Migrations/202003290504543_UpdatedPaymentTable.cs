namespace HospitalManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPaymentTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Payments");
            DropColumn("dbo.Payments", "PaymemntID");
            AddColumn("dbo.Payments", "PaymentID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Payments", "PaymentID");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "PaymemntID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Payments", "PaymemntID");
            DropPrimaryKey("dbo.Payments");
            DropColumn("dbo.Payments", "PaymentID");
            
        }
    }
}

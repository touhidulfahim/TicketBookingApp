namespace TicketBooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_SeatInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatNo = c.String(),
                        Rent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeatTypeId = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tb_SeatType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeatType = c.String(),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_SeatType");
            DropTable("dbo.tb_SeatInfo");
        }
    }
}

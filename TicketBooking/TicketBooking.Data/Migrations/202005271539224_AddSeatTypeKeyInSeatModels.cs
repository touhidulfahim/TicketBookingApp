namespace TicketBooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeatTypeKeyInSeatModels : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.tb_SeatInfo", "SeatTypeId");
            AddForeignKey("dbo.tb_SeatInfo", "SeatTypeId", "dbo.tb_SeatType", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_SeatInfo", "SeatTypeId", "dbo.tb_SeatType");
            DropIndex("dbo.tb_SeatInfo", new[] { "SeatTypeId" });
        }
    }
}

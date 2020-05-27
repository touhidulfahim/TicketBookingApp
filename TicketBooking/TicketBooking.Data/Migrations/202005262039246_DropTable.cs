namespace TicketBooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_CountryInfo", "CountryRegionId", "dbo.tb_CountryRegionInfo");
            DropForeignKey("dbo.tb_CityInfo", "CountryId", "dbo.tb_CountryInfo");
            DropIndex("dbo.tb_CityInfo", new[] { "CountryId" });
            DropIndex("dbo.tb_CountryInfo", new[] { "CountryRegionId" });
            DropTable("dbo.tb_CityInfo");
            DropTable("dbo.tb_CountryInfo");
            DropTable("dbo.tb_CountryRegionInfo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tb_CountryRegionInfo",
                c => new
                    {
                        CountryRegionId = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.CountryRegionId);
            
            CreateTable(
                "dbo.tb_CountryInfo",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        CountryRegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.tb_CityInfo",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityCode = c.String(),
                        CityName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateIndex("dbo.tb_CountryInfo", "CountryRegionId");
            CreateIndex("dbo.tb_CityInfo", "CountryId");
            AddForeignKey("dbo.tb_CityInfo", "CountryId", "dbo.tb_CountryInfo", "CountryId");
            AddForeignKey("dbo.tb_CountryInfo", "CountryRegionId", "dbo.tb_CountryRegionInfo", "CountryRegionId");
        }
    }
}

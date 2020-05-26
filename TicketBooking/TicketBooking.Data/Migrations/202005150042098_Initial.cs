namespace TicketBooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_CityInfo",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        CityCode = c.String(),
                        CityName = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.tb_CountryInfo", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.tb_CountryInfo",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        CountryRegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.tb_CountryRegionInfo", t => t.CountryRegionId)
                .Index(t => t.CountryRegionId);
            
            CreateTable(
                "dbo.tb_CountryRegionInfo",
                c => new
                    {
                        CountryRegionId = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.CountryRegionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_CityInfo", "CountryId", "dbo.tb_CountryInfo");
            DropForeignKey("dbo.tb_CountryInfo", "CountryRegionId", "dbo.tb_CountryRegionInfo");
            DropIndex("dbo.tb_CountryInfo", new[] { "CountryRegionId" });
            DropIndex("dbo.tb_CityInfo", new[] { "CountryId" });
            DropTable("dbo.tb_CountryRegionInfo");
            DropTable("dbo.tb_CountryInfo");
            DropTable("dbo.tb_CityInfo");
        }
    }
}

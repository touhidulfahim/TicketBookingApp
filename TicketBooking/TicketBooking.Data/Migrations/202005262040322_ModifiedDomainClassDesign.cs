namespace TicketBooking.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedDomainClassDesign : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_CityInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityCode = c.String(),
                        CityName = c.String(),
                        CountryId = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_CountryInfo", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.tb_CountryInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        CountryRegionId = c.Int(nullable: false),
                        CreatedBy = c.Int(),
                        ModifiedBy = c.Int(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tb_CountryRegionInfo", t => t.CountryRegionId)
                .Index(t => t.CountryRegionId);
            
            CreateTable(
                "dbo.tb_CountryRegionInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionName = c.String(),
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

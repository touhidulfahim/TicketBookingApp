using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Data.Gateway
{
    public class TicketBookingDbContext:DbContext
    {
        public TicketBookingDbContext():base("TicketBookingDbConnection")
        {
            
        }



        public DbSet<CountryRegionModels> CountryRegionEntity { get; set; }
        public DbSet<CountryModel> CountryEntity { get; set; }
        public DbSet<CityModel> CityEntity { get; set; }
        public DbSet<SeatTypeModel> SeatTypeEntity { get; set; }
        public DbSet<SeatModel> SeatEntity { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.Gateway;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Data.Repositories.CountryRegion
{
    public class CountryRegionRepository: RepositoryBase<CountryRegionModels>, ICountryRegionRepository
    {
        public CountryRegionRepository(TicketBookingDbContext context):base(context) 
        {
        }
    }
}

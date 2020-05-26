using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.Gateway;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Data.Repositories.Country
{
    public class CountryRepository : RepositoryBase<CountryModel>, ICountryRepository
    {
        public CountryRepository(TicketBookingDbContext context) : base(context)
        {
        }
    }
}

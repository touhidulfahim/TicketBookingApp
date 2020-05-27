using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.Gateway;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Data.Repositories.City
{
    public class CityRepository:RepositoryBase<CityModel>,ICityRepository
    {
        public CityRepository(TicketBookingDbContext context) : base(context)
        {
        }
    }
}

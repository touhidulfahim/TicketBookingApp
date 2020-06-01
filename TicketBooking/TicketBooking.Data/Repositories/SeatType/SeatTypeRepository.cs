using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.Gateway;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Data.Repositories.SeatType
{
    public class SeatTypeRepository:RepositoryBase<SeatTypeModel>,ISeatTypeRepository
    {
        public SeatTypeRepository(TicketBookingDbContext context) : base(context)
        {
        }
    }
}

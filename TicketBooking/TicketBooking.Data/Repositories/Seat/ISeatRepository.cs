using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Data.Repositories.Seat
{
    public interface ISeatRepository:IRepository<SeatModel>
    {
    }
}

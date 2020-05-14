using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Data.Gateway
{
    public class TicketBookingDbContext:DbContext
    {
        public TicketBookingDbContext():base("TicketBookingDbConnection")
        {
            
        }





    }
}

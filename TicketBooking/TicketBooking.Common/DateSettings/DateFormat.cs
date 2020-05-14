using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Common.DateSettings
{
    public class DateFormat : IDateFormat
    {
        public DateTime GetDate()
        {
            return DateTime.Now.Date;
        }
    }
}

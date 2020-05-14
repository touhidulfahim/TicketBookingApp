using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Common.DateSettings
{
    public class TimeFormat:ITimeFormat
    {
        public TimeSpan GetTime()
        {
            return DateTime.Now.TimeOfDay;
        }
    }
}

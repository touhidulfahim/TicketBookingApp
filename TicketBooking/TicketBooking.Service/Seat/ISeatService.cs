using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.DTO;

namespace TicketBooking.Service.Seat
{
    public interface ISeatService
    {
        IEnumerable<SeatDto> GetSeatList();
        SeatDto GetSeatDetails(int? id);
        void InsertSeat(SeatDto seatDto);
        void UpdateSeat(SeatDto seatDto);
        bool IsSeatAlreadyExists(SeatDto seatDto);
        void SaveSeat();
    }
}

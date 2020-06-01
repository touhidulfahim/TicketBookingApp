using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.DTO;

namespace TicketBooking.Service.SeatType
{
    public interface ISeatTypeService
    {
        IEnumerable<SeatTypeDto> GetSeatTypeList();
        SeatTypeDto GetSeatTypeDetails(int? id);
        void InsertSeatType(SeatTypeDto seatTypeDto);
        void UpdateSeatType(SeatTypeDto seatTypeDto);
        bool IsSeatTypeAlreadyExists(SeatTypeDto seatTypeDto);
        void SaveSeatType();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Common.Converter;
using TicketBooking.Data.Repositories.Seat;
using TicketBooking.Domain.DTO;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.Seat
{
    public class SeatService:ISeatService
    {
        private readonly ISeatRepository _iSeatRepository;

        public SeatService(ISeatRepository iSeatRepository)
        {
            _iSeatRepository = iSeatRepository;
        }

        public SeatDto GetSeatDetails(int? id)
        {
            SeatModel seatModel = _iSeatRepository.GetById(id);
            SeatDto seatDto = ObjectConverter<SeatModel, SeatDto>.Convert(seatModel);
            return seatDto;
        }

        public IEnumerable<SeatDto> GetSeatList()
        {
            List<SeatModel> seatModel = _iSeatRepository.GetAll().ToList();
            List<SeatDto> seatDto = ObjectConverter<SeatModel, SeatDto>.ConvertList(seatModel).ToList();
            return seatDto;
        }

        public void InsertSeat(SeatDto seatDto)
        {
            SeatModel seatModel=  ObjectConverter<SeatDto,SeatModel >.Convert(seatDto);
            _iSeatRepository.Insert(seatModel);
        }

        public bool IsSeatAlreadyExists(SeatDto seatDto)
        {
            var seatList = _iSeatRepository.GetAll().ToList();
            return (from s in seatList
                where s.SeatNo == seatDto.SeatNo &&
                      s.Rent == seatDto.Rent &&
                      s.SeatTypeId == seatDto.SeatTypeId
                select s).Any();
        }

        public void SaveSeat()
        {
            _iSeatRepository.Commit();
        }

        public void UpdateSeat(SeatDto seatDto)
        {
            SeatModel seatModel = ObjectConverter<SeatDto, SeatModel>.Convert(seatDto);
            _iSeatRepository.Insert(seatModel);
        }
    }
}

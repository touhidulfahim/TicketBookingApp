using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Common.Converter;
using TicketBooking.Data.Repositories.SeatType;
using TicketBooking.Domain.DTO;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.SeatType
{
    public class SeatTypeService:ISeatTypeService
    {
        private readonly ISeatTypeRepository _iSeatTypeRepository;

        public SeatTypeService(ISeatTypeRepository iSeatTypeRepository)
        {
            _iSeatTypeRepository = iSeatTypeRepository;
        }

        public SeatTypeDto GetSeatTypeDetails(int? id)
        {
            SeatTypeModel seatType = _iSeatTypeRepository.GetById(id);
            SeatTypeDto seatTypeDto = ObjectConverter<SeatTypeModel, SeatTypeDto>.Convert(seatType);
            return seatTypeDto;
        }

        public IEnumerable<SeatTypeDto> GetSeatTypeList()
        {
            List<SeatTypeModel> seatType = _iSeatTypeRepository.GetAll().ToList();
            List<SeatTypeDto> seatTypeDto = ObjectConverter<SeatTypeModel, SeatTypeDto>.ConvertList(seatType).ToList();
            return seatTypeDto;
        }

        public void InsertSeatType(SeatTypeDto seatTypeDto)
        {
            SeatTypeModel seatType= ObjectConverter<SeatTypeDto,SeatTypeModel>.Convert(seatTypeDto);
            _iSeatTypeRepository.Insert(seatType);
        }

        public bool IsSeatTypeAlreadyExists(SeatTypeDto seatTypeDto)
        {
            var seatTypeList = _iSeatTypeRepository.GetAll().ToList();
            return (from st in seatTypeList
                where st.SeatType == seatTypeDto.SeatType
                select st).Any();
        }

        public void SaveSeatType()
        {
            _iSeatTypeRepository.Commit();
        }

        public void UpdateSeatType(SeatTypeDto seatTypeDto)
        {
            SeatTypeModel seatType = ObjectConverter<SeatTypeDto, SeatTypeModel>.Convert(seatTypeDto);
            _iSeatTypeRepository.Update(seatType);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.DTO;

namespace TicketBooking.Service.City
{
    public interface ICityService
    {
        IEnumerable<CityDto> GetCityList();
        CityDto GetCityDetails(int? id);
        void Insert(CityDto cityDto);
        void Update(CityDto cityDto);
        bool IsAlreadyExists(CityDto cityDto);
        void Save();
    }
}

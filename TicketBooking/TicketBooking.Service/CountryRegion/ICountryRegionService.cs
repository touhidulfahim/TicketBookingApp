using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.DTO;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.CountryRegion
{
    public interface ICountryRegionService
    {
        IEnumerable<CountryRegionDto> GetAllCountryRegion();
        CountryRegionDto GetDetailById(int id);
        void Insert(CountryRegionDto countryRegionDto);
        void Update(CountryRegionDto countryRegionDto);
        void SaveCountryRegion();
    }
}

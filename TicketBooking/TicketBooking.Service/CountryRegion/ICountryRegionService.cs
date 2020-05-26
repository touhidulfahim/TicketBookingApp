using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.CountryRegion
{
    public interface ICountryRegionService
    {
        IEnumerable<CountryRegionModels> GetAllCountryRegion();
        CountryRegionModels GetDetailById(int id);
        void Insert(CountryRegionModels countryRegion);
        void Update(CountryRegionModels countryRegion);
        void SaveCountryRegion();
    }
}

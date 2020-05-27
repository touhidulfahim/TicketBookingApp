using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.DTO;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.Country
{
    public interface ICountryService
    {
        IEnumerable<CountryDto> GetCountryList();
        CountryDto GetCountryDetails(int? id);
        void Insert(CountryDto country);
        void Update(CountryDto country);
        void SaveCountry();
        bool IsAlreadyExists(CountryDto countryModel);
    }
}

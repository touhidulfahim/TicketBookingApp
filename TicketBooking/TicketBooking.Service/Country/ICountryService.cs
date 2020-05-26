using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.Country
{
    public interface ICountryService
    {
        IEnumerable<CountryModel> GetCountryList();
        CountryModel GetCountryDetails(int? id);
        void Insert(CountryModel country);
        void Update(CountryModel country);
        void SaveCountry();
        bool IsAlreadyExists(CountryModel countryModel);
    }
}

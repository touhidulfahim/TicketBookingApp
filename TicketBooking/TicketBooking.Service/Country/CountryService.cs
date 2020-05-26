using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Data.Repositories.Country;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.Country
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public IEnumerable<CountryModel> GetCountryList()
        {
            return countryRepository.GetAll();
        }

        public CountryModel GetCountryDetails(int? id)
        {
            throw new NotImplementedException();
        }

        public void Insert(CountryModel country)
        {
            countryRepository.Insert(country);
        }

        public void Update(CountryModel country)
        {
            countryRepository.Update(country);
        }

        public void SaveCountry()
        {
            countryRepository.Commit();
        }

        public bool IsAlreadyExists(CountryModel countryModel)
        {
            var countryList = countryRepository.GetAll();
            return (from c in countryList
                    where c.CountryCode == countryModel.CountryCode && 
                          c.CountryName == countryModel.CountryName &&
                          c.CountryRegionId == countryModel.CountryRegionId
                    select c).Any();
        }

    }
}

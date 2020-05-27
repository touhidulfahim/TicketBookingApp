using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Common.Converter;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Data.Repositories.Country;
using TicketBooking.Domain.DTO;
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

        public IEnumerable<CountryDto> GetCountryList()
        {
           List<CountryModel> country= countryRepository.GetAll().ToList();
           List<CountryDto> countryDto = ObjectConverter<CountryModel, CountryDto>.ConvertList(country).ToList();
           return countryDto;
        }

        public CountryDto GetCountryDetails(int? id)
        {
            CountryModel country = countryRepository.GetById(id);
            CountryDto countryDto = ObjectConverter<CountryModel, CountryDto>.Convert(country);
            return countryDto;
        }

        public void Insert(CountryDto countryDto)
        {
            CountryModel country=  ObjectConverter<CountryDto, CountryModel>.Convert(countryDto);
            countryRepository.Insert(country);
        }

        public void Update(CountryDto countryDto)
        {
            CountryModel country = ObjectConverter<CountryDto, CountryModel>.Convert(countryDto);
            countryRepository.Update(country);
        }

        public void SaveCountry()
        {
            countryRepository.Commit();
        }

        public bool IsAlreadyExists(CountryDto countryModel)
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

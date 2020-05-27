using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Common.Converter;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Data.Repositories.Country;
using TicketBooking.Data.Repositories.CountryRegion;
using TicketBooking.Domain.DTO;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.CountryRegion
{
    public class CountryRegionService:ICountryRegionService
    {
        private readonly ICountryRegionRepository _repository;

        public CountryRegionService(ICountryRegionRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CountryRegionDto> GetAllCountryRegion()
        {
            List<CountryRegionModels> countryRegion = _repository.GetAll().ToList();
            List<CountryRegionDto>CountryRegionDto=ObjectConverter<CountryRegionModels, CountryRegionDto>.ConvertList(countryRegion).ToList();
            return CountryRegionDto;
        }

        public CountryRegionDto GetDetailById(int id)
        {
           CountryRegionModels countryRegion = _repository.GetById(id);
           CountryRegionDto countryRegionDto =
               ObjectConverter<CountryRegionModels, CountryRegionDto>.Convert(countryRegion);
           return countryRegionDto;
        }
        

        public void Insert(CountryRegionDto countryRegionDto)
        {
            CountryRegionModels countryRegion =
                ObjectConverter<CountryRegionDto, CountryRegionModels>.Convert(countryRegionDto);
            _repository.Insert(countryRegion);
        }

        public void Update(CountryRegionDto countryRegionDto)
        {
            CountryRegionModels countryRegion =
                ObjectConverter<CountryRegionDto, CountryRegionModels>.Convert(countryRegionDto);
            _repository.Update(countryRegion);
        }

        public void SaveCountryRegion()
        {
            _repository.Commit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Data.Infrastructure;
using TicketBooking.Data.Repositories.Country;
using TicketBooking.Data.Repositories.CountryRegion;
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

        public IEnumerable<CountryRegionModels> GetAllCountryRegion()
        {
            var countryRegionList= _repository.GetAll();
            return (from cr in countryRegionList orderby cr.RegionName select cr);
        }

        public CountryRegionModels GetDetailById(int id)
        {
           return _repository.GetById(id);
        }
        

        public void Insert(CountryRegionModels countryRegion)
        {
            _repository.Insert(countryRegion);
        }

        public void Update(CountryRegionModels countryRegion)
        {
            _repository.Update(countryRegion);
        }

        public void SaveCountryRegion()
        {
            _repository.Commit();
        }
    }
}

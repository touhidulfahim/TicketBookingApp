using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Common.Converter;
using TicketBooking.Data.Repositories.City;
using TicketBooking.Domain.DTO;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.City
{
    public class CityService:ICityService
    {
        private readonly ICityRepository _iCityRepository;

        public CityService(ICityRepository iCityRepository)
        {
            _iCityRepository = iCityRepository;
        }

        public IEnumerable<CityDto> GetCityList()
        {
            List<CityModel> cityModel = _iCityRepository.GetAll().ToList();
            List<CityDto> cityDto = ObjectConverter<CityModel,CityDto>.ConvertList(cityModel).ToList();
            return cityDto;
        }

        public CityDto GetCityDetails(int? id)
        {
            CityModel cityModel = _iCityRepository.GetById(id);
            CityDto cityDto = ObjectConverter<CityModel, CityDto>.Convert(cityModel);
            return cityDto;
        }

        
        public void Insert(CityDto cityDto)
        {
            CityModel cityModel= ObjectConverter<CityDto, CityModel>.Convert(cityDto);
            _iCityRepository.Insert(cityModel);
        }

        public bool IsAlreadyExists(CityDto cityDto)
        {
            var cityList = _iCityRepository.GetAll();
            return (from ci in cityList
                where ci.CityCode == cityDto.CityCode &&
                      ci.CityName == cityDto.CityName &&
                      ci.CountryId == cityDto.CountryId
                select ci).Any();
        }

        public void Update(CityDto cityDto)
        {
            CityModel cityModel = ObjectConverter<CityDto, CityModel>.Convert(cityDto);
            _iCityRepository.Update(cityModel);
        }

        public void Save()
        {
            _iCityRepository.Commit();
        }

    }
}

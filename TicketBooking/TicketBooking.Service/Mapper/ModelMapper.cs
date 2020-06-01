using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.DTO;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Service.Mapper
{
    public static class ModelMapper
    {
        public static void SetUp()
        {
            AutoMapper.Mapper.Initialize(cfg=>
            {
                cfg.CreateMap<CountryRegionModels, CountryRegionDto>();
                cfg.CreateMap<CountryModel, CountryDto>();
                cfg.CreateMap<CityModel, CityDto>();
                cfg.CreateMap<SeatTypeModel, SeatTypeDto>();
                cfg.CreateMap<SeatModel, SeatDto>();



                //=========
                cfg.CreateMap<CountryRegionDto, CountryRegionModels>();
                cfg.CreateMap<CountryDto, CountryModel>();
                cfg.CreateMap<CityDto, CityModel>();
                cfg.CreateMap<SeatTypeDto, SeatTypeModel>();
                cfg.CreateMap<SeatDto, SeatModel>();
            });
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketBooking.Domain.Shared;

namespace TicketBooking.Domain.Entity
{
    [Table("tb_CountryRegionInfo")]
    public class CountryRegionModels: BaseEntity
    {
        
        public string RegionName { get; set; }

    }
}
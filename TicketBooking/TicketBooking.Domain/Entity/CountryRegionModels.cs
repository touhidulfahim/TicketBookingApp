using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketBooking.Domain.Entity
{
    [Table("tb_CountryRegionInfo")]
    public class CountryRegionModels
    {
        [Key]
        public int CountryRegionId { get; set; }
        public string RegionName { get; set; }

    }
}
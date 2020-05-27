using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.Shared;

namespace TicketBooking.Domain.Entity
{
    [Table("tb_CityInfo")]
    public class CityModel:BaseEntity
    {
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public virtual CountryModel Countries { get; set; }
    }
}

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
    [Table("tb_CountryInfo")]
    public class CountryModel:BaseEntity
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int CountryRegionId { get; set; }

        [ForeignKey("CountryRegionId")]
        public virtual CountryRegionModels CountryRegions { get; set; }
    }
}

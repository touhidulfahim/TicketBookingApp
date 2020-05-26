using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Domain.Entity
{
    [Table("tb_CountryInfo")]
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public int CountryRegionId { get; set; }



        [ForeignKey("CountryRegionId")]
        public virtual CountryRegionModels CountryRegions { get; set; }
    }
}

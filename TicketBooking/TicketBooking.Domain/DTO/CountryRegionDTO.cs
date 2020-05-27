using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.Shared;

namespace TicketBooking.Domain.DTO
{
    public class CountryRegionDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Region")]
        public string RegionName { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        

    }
}

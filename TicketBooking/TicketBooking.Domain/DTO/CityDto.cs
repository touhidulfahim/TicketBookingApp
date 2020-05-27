using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.Entity;

namespace TicketBooking.Domain.DTO
{
    public class CityDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Code")]
        public string CityCode { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string CityName { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CountryDto Countries { get; set; }
    }
}

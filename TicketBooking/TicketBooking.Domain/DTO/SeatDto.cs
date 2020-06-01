using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketBooking.Domain.DTO
{
    public class SeatDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Seat No")]
        public string SeatNo { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Rent { get; set; }
        [Required]
        [Display(Name = "Type")]
        public int SeatTypeId { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public virtual SeatTypeDto SeatTypes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.Shared;

namespace TicketBooking.Domain.Entity
{
    [Table("tb_SeatInfo")]
    public class SeatModel:BaseEntity
    {
        public string SeatNo { get; set; }
        public decimal Rent { get; set; }
        public int SeatTypeId { get; set; }

        [ForeignKey("SeatTypeId")]
        public virtual SeatTypeModel SeatTypes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketBooking.Domain.Shared;

namespace TicketBooking.Domain.Entity
{
    [Table("tb_SeatType")]
    public class SeatTypeModel:BaseEntity
    {
        public string SeatType { get; set; }
    }
}

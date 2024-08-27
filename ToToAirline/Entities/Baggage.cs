using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToToAirline.Entities
{
    public class Baggage
    {
        public Baggage(int weightInKg, Guid bookingId)
        {
            Id = Guid.NewGuid();
            WeightInKg = weightInKg;
            BookingId = bookingId;
            Create = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public int WeightInKg { get; set; }
        public DateTime Create { get; set; }
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
    }
}
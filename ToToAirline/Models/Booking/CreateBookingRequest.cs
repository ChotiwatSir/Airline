using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToToAirline.Models.Booking
{
    public class CreateBookingRequest
    {
        public CreateBookingRequest(string flightId, bool status, string bookingPaltform, Guid passengerId)
        {
            FlightId = flightId;
            Status = status;
            BookingPaltform = bookingPaltform;
            PassengerId = passengerId;
        }

        public string FlightId { get; set; } = string.Empty;
        public bool Status { get; set; }
        public string BookingPaltform { get; set; } = string.Empty;
        public Guid PassengerId { get; set; }
        
    }
}
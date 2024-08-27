using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToToAirline.Models.FlightManifest
{
    public class CreateFlightManifestRequest
    {
        public CreateFlightManifestRequest(Guid bookingId, Guid flightId)
        {
            BookingId = bookingId;
            FlightId = flightId;
        }

        public Guid BookingId { get; set; }
        public Guid FlightId { get; set; }
    }
}
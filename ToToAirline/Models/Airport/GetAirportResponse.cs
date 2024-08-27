

namespace ToToAirline.Models.Passenger.Airport
{
    public class GetAirportResponse
    {
        public GetAirportResponse(Guid id, string airportName, string county, string state, string city)
        {
            Id = id;
            AirportName = airportName;
            County = county;
            State = state;
            City = city;
        }

        public Guid Id { get;  }
        public string AirportName { get;  } = string.Empty;
        public string County { get;  } = string.Empty;
        public string State { get;  } = string.Empty;
        public string City { get;  } = string.Empty;
    }
}
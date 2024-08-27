

using System.ComponentModel.DataAnnotations;

namespace ToToAirline.Models.Passenger.Airport
{
    public class CreateAirportRequest
    {
     
        [Required]
        [MaxLength(20)]
        public string AirportName { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string County { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string State { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string City { get; set; } = string.Empty;
    }
}
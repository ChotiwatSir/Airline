using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ToToAirline.Entities;

namespace ToToAirline.Context
{
    public class ContextDb : DbContext
    {
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Baggage> Baggages { get; set; }
        public DbSet<BaggageCheck> BaggageChecks { get; set; }
        public DbSet<BoardingPass> BoardingPasses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightManifest> FlightManifests { get; set; }
        public DbSet<NoFlyList> NoFlyLists { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<SecurityCheck> SecurityChecks { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = localhost; user = sa; password = Sirinam44; database = AirlineDb; trustservercertificate = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
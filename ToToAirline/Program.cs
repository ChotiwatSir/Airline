using ToToAirline.Context;
using ToToAirline.Entities;
using ToToAirline.IRepository;
using ToToAirline.IService;
using ToToAirline.MiddleWare;
using ToToAirline.Repository;
using ToToAirline.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepository<Airline>, Repository<Airline>>();
builder.Services.AddScoped<IRepository<Airport>, Repository<Airport>>();
builder.Services.AddScoped<IRepository<Baggage>, Repository<Baggage>>();
builder.Services.AddScoped<IRepository<BaggageCheck>, Repository<BaggageCheck>>();
builder.Services.AddScoped<IRepository<BoardingPass>, Repository<BoardingPass>>();
builder.Services.AddScoped<IRepository<Booking>, Repository<Booking>>();
builder.Services.AddScoped<IRepository<Flight>, Repository<Flight>>();
builder.Services.AddScoped<IRepository<NoFlyList>, Repository<NoFlyList>>();
builder.Services.AddScoped<IRepository<Passenger>, Repository<Passenger>>();
builder.Services.AddScoped<IRepository<SecurityCheck>, Repository<SecurityCheck>>();
builder.Services.AddScoped<IRepository<FlightManifest>, Repository<FlightManifest>>();

builder.Services.AddScoped<IAirlineService, AirlineService>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IBaggageService, BaggageService>();
builder.Services.AddScoped<IBaggageCheckService, BaggageCheckService>();
builder.Services.AddScoped<IBoardingPassService, BoardingPassService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddScoped<INoFlyListService, NoFlyListService>();
builder.Services.AddScoped<IPassengerService, PassengerService>();
builder.Services.AddScoped<ISecurityCheckService, SecurityCheckService>();
builder.Services.AddScoped<IFlightManiFestService, FlightManiFestService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDb>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHanddle>();
app.MapControllers();
app.Run();



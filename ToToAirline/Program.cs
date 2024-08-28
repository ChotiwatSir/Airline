using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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
builder.Services.AddScoped<IRepository<User>, Repository<User>>();

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
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ContextDb>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});


builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHanddle>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();



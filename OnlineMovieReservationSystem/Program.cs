using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using System.Configuration;
using System;
using OnlineMovieReservationSystem.Services.MovieService;
using OnlineMovieReservationSystem.Services.VenueService;
using OnlineMovieReservationSystem.Services.TimetableService;
using OnlineMovieReservationSystem.Services.SessionService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddDbContext<DataContext>(options =>
{
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();

    //string connection = Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(@"Server=localhost;Port=5432;Database=OMRS;User Id=postgres;Password=calceyPG");
 });*/

builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("MovieReservationDb"));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<ISessionService, SessionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

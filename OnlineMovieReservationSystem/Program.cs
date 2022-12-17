using Microsoft.EntityFrameworkCore;
using MediatR;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Application;
using OnlineMovieReservationSystem.Application.Data;
using OnlineMovieReservationSystem.Application.Services.MovieService;
using OnlineMovieReservationSystem.Application.Services.SessionService;
using OnlineMovieReservationSystem.Application.Services.VenueService;

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

builder.Services.AddMediatR(typeof(MediatorEntryPoint).Assembly);

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
using Microsoft.EntityFrameworkCore;
using MediatR;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Application;
using OnlineMovieReservationSystem.Application.Services.MovieService;
using OnlineMovieReservationSystem.Application.Services.SessionService;
using OnlineMovieReservationSystem.Application.Services.VenueService;
using OnlineMovieReservationSystem.Persistence.Data;
using OnlineMovieReservationSystem.Persistence.Repositories;
using OnlineMovieReservationSystem.Domain.Repositories.MovieRepository;
using OnlineMovieReservationSystem.Persistence.Repositories.MovieRepository;
using OnlineMovieReservationSystem.Domain.Repositories.VenueRepository;
using OnlineMovieReservationSystem.Persistence.Repositories.VenueRepository;

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

builder.Services.AddDbContext<DataContext>(options =>
{
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
    //string connection = Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(@"Server=localhost;Port=5432;Database=OMRS;User Id=postgres;Password=calceyPG", b => b.MigrationsAssembly("OnlineMovieReservationSystem.Persistence"));
 });

builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddScoped<IUnitOfWork, DataContext>();

//builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("MovieReservationDb"));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IVenueService, VenueService>();
builder.Services.AddScoped<ISessionService, SessionService>();

// Repositories

builder.Services.AddScoped<IMovieQueryRepository, MovieQueryRepository>();
builder.Services.AddScoped<IMovieCommandRepository, MovieCommandRepository>();
builder.Services.AddScoped<IVenueQueryRepository, VenueQueryRepository>();
builder.Services.AddScoped<IVenueCommandRepository, VenueCommandRepository>();

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
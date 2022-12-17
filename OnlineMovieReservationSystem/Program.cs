using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Application.Services.MovieService;
using OnlineMovieReservationSystem.Application.Services.VenueService;
using OnlineMovieReservationSystem.Application.Services.SessionService;
using MediatR;
using OnlineMovieReservationSystem.Domain.Services;
using OnlineMovieReservationSystem.Application;
using OnlineMovieReservationSystem.Application.Data;

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
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseSwagger();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi v1"));
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

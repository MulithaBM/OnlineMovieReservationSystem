using Microsoft.EntityFrameworkCore;
using OnlineMovieReservationSystem.Data;
using System.Configuration;
using System;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("*");
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
